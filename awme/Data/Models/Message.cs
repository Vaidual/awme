using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public DateTime SentAt { get; set; }
        public string Content { get; set; }
    }

}
