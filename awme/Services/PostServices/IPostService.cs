using awme.Data.Dto.Post;
using awme.Data.Models;

namespace awme.Services.PostServices
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<List<Post>> GetProfilePosts(int profileId);
        Task<Post?> GetPost(int id);
        Task<Post> AddPost(PostAddRequest request, Profile profile);
        Task<bool> DeletePost(int id);
        Task<Post> UpdatePost(Post post, PostUpdateRequest update);
    }
}
