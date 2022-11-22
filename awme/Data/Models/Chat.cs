using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string FirstUserId { get; set; }
        [JsonIgnore]
        public Profile FirstUser { get; set; }
        public string SecondUserId { get; set; }
        [JsonIgnore]
        public Profile SecondUser { get; set; }
        public List<Message> Messages { get; set; }
    }
}
