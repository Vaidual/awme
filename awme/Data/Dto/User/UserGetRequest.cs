using awme.Data.Models;

namespace awme.Data.Dto.User
{
    public class UserGetRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.User;
        public List<Models.Animal> Animals { get; set; }
        public List<Collar> Collars { get; set; }
        public Models.Profile Profile { get; set; }
    }
}
