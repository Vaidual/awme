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
            await _userService.UpdateUser(user, userUpdates);
            return NoContent();
        }

        [HttpDelete(), Authorize(Roles = "User")]
        public async Task<ActionResult> DeleteWithApproving(UserLoginRequest request)
        {
            User? user = await _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            if (!HashController.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return StatusCode(403, "Wrong password.");
            }
            await _userService.DeleteUser(user.Id);
            return Ok();
        }

        [HttpDelete("delete-by-id/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
