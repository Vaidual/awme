using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        [JsonIgnore]
        public User FirstUser { get; set; }
        public int SecondUserId { get; set; }
        [JsonIgnore]
        public User SecondUser { get; set; }
        public List<Message> Messages { get; set; }
    }
}
