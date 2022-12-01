using AutoMapper;
using awme.Data.Dto.Post;
using awme.Data.Models;
using awme.Migrations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Profile = awme.Data.Models.Profile;

namespace awme.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Post> AddPost(PostAddRequest request, Profile profile)
        {
            var post = _mapper.Map(request, new Post { CreatedAt = DateTime.Now, Profile = profile });
            var result = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post? result = await GetPost(id);
            if (result == null)
            {
                return false;
            }
            _context.Posts.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Post?> GetPost(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetProfilePosts(int profileId)
        {
            return await _context.Posts.Where(p => p.ProfileId == profileId).ToListAsync();
        }

        public async Task<Post> UpdatePost(Post post, PostUpdateRequest update)
        {
            _mapper.Map(update, post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
