using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using Serilog;
using System.Text;
using MQTTnet.Server;
using awme.Services.AnimalActivityServices;
using awme.Data.Dto.AnimalActivity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



namespace awme.Controllers
{
    public class AnimalDataController
    {
        private readonly IAnimalActivityService? _animalActivityService;

        public AnimalDataController(IAnimalActivityService? animalActivityService)
        {
            this._animalActivityService = animalActivityService;
        }

        public async void Handle_Received_Application_Message()
        {

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithClientId("Server")
                    .WithTcpServer("2e429513164340e1bf76e616ee62a30c.s2.eu.hivemq.cloud")
                    .WithCredentials("Vaidual", "12345687")
                    .WithTls()
                    .WithCleanSession()
                    .Build();

                // Setup message handling before connecting so that queued messages
                // are also handled properly. When there is no event handler attached all
                // received messages get lost.
                mqttClient.ApplicationMessageReceivedAsync += async e =>
                {
                    Console.WriteLine("Received application message.");
                    var data = Parse(e.ApplicationMessage.Payload);
                    AnimalActivityAddRequest activity = new AnimalActivityAddRequest
                    {
                        CollarId = data["deviceId"].ToString()!,
                        isActive = bool.Parse(data["isMoving"].ToString()!),
                        Time = DateTime.Now
                    };
                    await _animalActivityService!.AddActivity(activity);
                };

                var a = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                mqttClient.DisconnectedAsync += async e =>
                {
                    Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    try
                    {
                        await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
                    }
                    catch
                    {
                        Console.WriteLine("### RECONNECTING FAILED ###");
                    }
                };

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic("awme/move");
                        })
                    .Build();

                var b = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                Console.WriteLine("MQTT client subscribed to topic.");

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }

        public Dictionary<String, Object> Parse(byte[] json)
        {
            string jsonStr = Encoding.UTF8.GetString(json);
            return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr)!;
        }
    }
}
