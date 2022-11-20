using awme.Data.Dto.User;
using awme.Data.Models;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("get-by-id/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            if (user == null)
            {
                return BadRequest("The user does not exist.");
            }
            return Ok(user);
        }

        [HttpPatch("change-role-by-id"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> PatchRoleById(int id, string role)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            if (user == null)
            {
                return BadRequest("The user not exists.");
            }
            user.Role = role;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete"), Authorize(Roles = "User")]
        public async Task<ActionResult> Delete(UserLoginRequest request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Email == request.Email);
            if (user == null)
            {
                return BadRequest("The user does not exist.");
            }
            if (!HashController.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete-by-id/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            if (user == null)
            {
                return BadRequest("The user does not exist.");
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
