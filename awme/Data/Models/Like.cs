using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime LikedAt { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public Post post { get; set; }
        public int PostId { get; set; }
    }
}
