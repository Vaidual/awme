using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Profile Sender { get; set; }
        [ForeignKey("Username")]
        public int SenderUsername { get; set; }
        public DateTime SentAt { get; set; }
        public string Content { get; set; }
    }

}
