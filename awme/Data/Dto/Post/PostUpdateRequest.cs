using awme.Data.Models;

namespace awme.Data.Dto.Post
{
    public class PostUpdateRequest
    {
        public string Content { get; set; } = string.Empty;
        public string Images { get; set; }
    }
}
