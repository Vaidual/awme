using awme.Data.Models;

namespace awme.Data.Dto.Animal
{
    public class AnimalAddRequest
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string? AvatarImage { get; set; }
        public int AnimalTypeId { get; set; }
        public int UserId { get; set; }
    }
}
