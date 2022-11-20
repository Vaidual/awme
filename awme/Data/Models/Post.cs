using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<Like> Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
