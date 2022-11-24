using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.UserServices;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            return Ok(user);
        }

        [HttpPatch("{id}/{role}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Patch(int id, Role role)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user not exists.");
            }
            if (id.ToString() == User.FindFirstValue("Id"))
            {
                return BadRequest("You cannot change own role");
            }
            await _userService.UpdateUserRole(user, role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (!await _userService.DeleteUser(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete(UserLoginRequest request)
        {
            User? verifiedUser = await VerificationController.VerifyUserAsync(request, _userService);
            if (verifiedUser == null)
            {
                return Unauthorized("Wrong email or password");
            }
            if (!await _userService.DeleteUser(verifiedUser.Id))
                {
                    return NotFound();
                }
            return NoContent();
        }
    }
}
