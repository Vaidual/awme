using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace awme.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; } = Role.User;
        public List<Animal> Animals { get; set; }
        public Profile Profile { get; set; }
    }
}
