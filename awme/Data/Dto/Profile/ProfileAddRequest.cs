using awme.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.Profile
{
    public class ProfileAddRequest
    {
        [Required, MinLength(1)]
        public string Username { get; set; }
        [Required, MinLength(1)]
        public string Nickname { get; set; }
        public Gender? Gender { get; set; }
        public string? Location { get; set; }
        [Required]
        public bool IsBanned { get; set; }
        public DateTime? BanEnd { get; set; }
        public int UserId { get; set; }
    }
}
