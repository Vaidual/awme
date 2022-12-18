using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.User
{
    public class UserRegisterRequest
    {
        [Required, MinLength(1)]
        public string FirstName { get; set; }
        [Required, MinLength(1)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
