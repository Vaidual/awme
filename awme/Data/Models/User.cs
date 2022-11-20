namespace awme.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Post> Posts { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
