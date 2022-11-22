namespace awme.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public Profile User { get; set; }
        public string UserId { get; set; }
    }
}
