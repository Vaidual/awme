using System.ComponentModel.DataAnnotations;

namespace awme.Data.DTO
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
