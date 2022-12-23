using awme.Data.Models;

namespace awme.Data.Dto.Profile
{
    public class ProfilesGetRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public Gender? Gender { get; set; }
        public string? Location { get; set; }
        public bool IsBanned { get; set; }
        public DateTime? BanEnd { get; set; }
        public int UserId { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
    }
}
