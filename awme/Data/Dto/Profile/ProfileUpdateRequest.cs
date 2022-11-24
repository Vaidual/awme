using awme.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.Profile
{
    public class ProfileUpdateRequest
    {
        [Required, MinLength(1)]
        public string Username { get; set; }
        [Required, MinLength(1)]
        public string Nickname { get; set; }
        public Gender? Gender { get; set; }
        public string? Location { get; set; }
    }
}
