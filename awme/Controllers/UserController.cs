using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.UserServices;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> Get()
        {
            List<User> users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            return Ok(user);
        }

        [HttpPatch("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<User> userUpdates)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user not exists.");
            }
            await _userService.UpdateUserFields(user, userUpdates);
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("validation"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> Check(UserLoginRequest request)
        {
            User? verifiedUser = await VerificationController.VerifyUserAsync(request, _userService);
            if (verifiedUser == null)
            {
                return Ok(false);
            }
            return Ok(true);
        }
    }
}
