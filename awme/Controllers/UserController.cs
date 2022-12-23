using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Services.CollarServices;
using awme.Services.UserServices;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePatch;
using System.Security.Claims;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICollarService _collarService;


        public UserController(IUserService userService, ICollarService collarService)
        {
            _userService = userService;
            this._collarService = collarService;
        }

        [HttpGet(), Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<List<UserGetRequest>>> Get()
        {
            List<UserGetRequest> users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}",Name = "GetUserById")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            return Ok(user);
        }

        [HttpGet("me")]
        public async Task<ActionResult<User>> GetMe()
        {
            string? id = User.FindFirstValue("Id");
            if (id == null)
            {
                return Unauthorized("You must authorize first.");
            }
            User? user = await _userService.GetUser(int.Parse(id));
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            return Ok(user);
        }

        [HttpPatch("{id}/{role}"), Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult> PatchRole(int id, Role role)
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

        [HttpPatch("{id}"), Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult> Patch(int id, Delta<User> patch)
        {
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("The user not exists.");
            }
            if (id.ToString() == User.FindFirstValue("id"))
            {
                return BadRequest("You cannot change own role");
            }
            user = await _userService.UpdateUserFields(user, patch);
            return Ok(user);
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

        [HttpPatch("/collar/{userId}/{collarId}")]
        public async Task<ActionResult> AddCollar(int userId, string collarId)
        {
            User? user = await _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound("The user not exists.");
            }
            Collar? collar = await _collarService.GetCollar(collarId);
            if (collar == null)
            {
                return NotFound("The collar not exists.");
            }
            if (collar.InUse)
            {
                return BadRequest("Collar aldready in use.");
            }
            await _userService.AddCollar(user, collar);
            return NoContent();
        }
    }
}
