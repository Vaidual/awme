using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace awme.Data.Models
{
    public class Collar
    {
        [Key, MinLength(1)]
        public string Id { get; set; }
        public bool InUse { get; set; } = false;
        public Animal Animal { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
