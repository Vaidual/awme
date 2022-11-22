using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProfileId { get; set; }
        [JsonIgnore]
        public Profile Profile { get; set; }
    }
}
