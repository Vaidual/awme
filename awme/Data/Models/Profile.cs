using System.ComponentModel.DataAnnotations;

namespace awme.Data.Models
{
    public class Profile
    {
        [Key]
        public string Username { get; set; }
        public string Nickname { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Following { get; set; }
        public List<Post> Posts { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
