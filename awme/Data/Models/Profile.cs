using System.ComponentModel.DataAnnotations;

namespace awme.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public Gender? Gender { get; set; }
        public string? Location { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Profile> Followers { get; set; } = new List<Profile>();
        public List<Profile> Following { get; set; } = new List<Profile>();
        public List<Post> Posts { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
