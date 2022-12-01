using awme.Data.Models;

namespace awme.Data.Dto.Post
{
    public class PostAddRequest
    {
        public string Content { get; set; } = string.Empty;
        public string Images { get; set; }
        public int ProfileId { get; set; }
    }
}
