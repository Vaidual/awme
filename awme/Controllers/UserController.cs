using awme.Data.DTO;
using awme.Data.Models;
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

        [HttpDelete("delete user")]
        public IActionResult Delete(UserDto request)
        {
            User? user = _context.Users.FirstOrDefault(el => el.Email == request.Email);
            if (user == null)
            {
                return BadRequest("No account found on email.");
            }
            if (!HashController.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }
            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
