using awme.Data.Dto.Profile;
using awme.Data.Models;
using awme.Services.PostServices;
using awme.Services.ProfileSevices;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileSevice _profileSevice;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public ProfileController(IProfileSevice profileSevice, IUserService userService, IPostService postService)
        {
            _profileSevice = profileSevice;
            _userService = userService;
            this._postService = postService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<ProfilesGetRequest>>> GetProfiles()
        {
            List<ProfilesGetRequest> profiles = await _profileSevice.GetProfiles();
            return Ok(profiles);
        }

        [HttpGet("{id}/posts")]
        public async Task<ActionResult<List<Post>>> GetProfilePosts(int id)
        {
            List<Post> posts = await _postService.GetProfilePosts(id);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            Profile? profile = await _profileSevice.GetProfile(id);
            if (profile == null)
            {
                return NotFound("The profile does not exist.");
            }
            return Ok(profile);
        }

        [HttpPost()]
        public async Task<ActionResult<Animal>> Add(ProfileAddRequest request)
        {
            User? user = await _userService.GetUser(request.UserId);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            if (user.Profile != null)
            {
                return BadRequest("The user already has profile.");
            }
            if (await _profileSevice.CheckIfUsernameIsTaken(request.Username))
            {
                return StatusCode(409, $"This username is already taken.");
            }
            var profile = await _profileSevice.AddProfile(request, user);
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (!await _profileSevice.DeleteProfile(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> Put(int id, ProfileUpdateRequest request)
        {
            Profile? profile = await _profileSevice.GetProfile(id);
            if (profile == null)
            {
                return NotFound("The profile does not exist.");
            }
            if (profile.Username != request.Username && await _profileSevice.CheckIfUsernameIsTaken(request.Username))
            {
                return StatusCode(409, $"This username is already taken.");
            }
            await _profileSevice.UpdateProfile(profile, request);
            return profile;
        }

        [HttpPatch("ban/{id}")]
        public async Task<ActionResult<Profile>> PatchBan(int id, [FromBody] ProfileBanPatchRequest patch)
        {
            Profile? profile = await _profileSevice.GetProfile(id);
            if (profile == null)
            {
                return NotFound("The profile does not exist.");
            }
            await _profileSevice.UpdateProfileBan(profile, patch);
            return profile;
        }
    }
}
