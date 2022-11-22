using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string FirstProfileUsername { get; set; }
        [JsonIgnore]
        public Profile FirstProfile { get; set; }
        public string SecondProfileUsername { get; set; }
        [JsonIgnore]
        public Profile SecondProfile { get; set; }
        public List<Message> Messages { get; set; }
    }
}
