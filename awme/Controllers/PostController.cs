using awme.Data.Dto.Post;
using awme.Data.Models;
using awme.Services.PostServices;
using awme.Services.ProfileSevices;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IProfileSevice _profileSevice;
        private readonly IPostService _postService;

        public PostController(IProfileSevice profileSevice, IPostService postService)
        {
            _profileSevice = profileSevice;
            this._postService = postService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            List<Post> posts = await _postService.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            Post? post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound("The post does not exist.");
            }
            return Ok(post);
        }

        [HttpPost()]
        public async Task<ActionResult<Post>> Add(PostAddRequest request)
        {
            Profile? profile = await _profileSevice.GetProfile(request.ProfileId);
            if (profile == null)
            {
                return NotFound("The profile does not exist.");
            }
            var post = await _postService.AddPost(request, profile);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (!await _postService.DeletePost(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Put(int id, PostUpdateRequest request)
        {
            Post? post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound("The post does not exist.");
            }
            await _postService.UpdatePost(post, request);
            return post;
        }
    }
}
