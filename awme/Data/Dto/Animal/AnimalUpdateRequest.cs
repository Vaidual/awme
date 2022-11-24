using awme.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.Animal
{
    public class AnimalUpdateRequest
    {
        [Required, MinLength(1)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        public string Description { get; set; }
        public string? AvatarImage { get; set; }
        [Required]
        public int TypeId { get; set; }
    }
}
