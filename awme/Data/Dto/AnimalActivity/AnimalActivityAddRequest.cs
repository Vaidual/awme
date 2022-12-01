using awme.Data.Models;

namespace awme.Data.Dto.AnimalActivity
{
    public class AnimalActivityAddRequest
    {
        public DateTime Time { get; set; }
        public bool isActive { get; set; }
        public string CollarId { get; set; }
    }
}
