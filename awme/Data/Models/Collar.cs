using System.ComponentModel.DataAnnotations;

namespace awme.Data.Models
{
    public class Collar
    {
        [Key]
        public string Id { get; set; }
        public bool InUse { get; set; } = false;
        public Animal Animal { get; set; }
    }
}
