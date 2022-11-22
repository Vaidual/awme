//using awme.Data.Dto.User;
//using awme.Data.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Data;

//namespace awme.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class ProfileController : ControllerBase
//    {
//        private readonly DataContext _context;
//        public ProfileController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("get-all")]
//        public async Task<ActionResult<List<Profile>>> Get()
//        {
//            List<Profile> profiles = _context.Profiles.ToList();
//            return Ok(profiles);
//        }

//        [HttpGet("get-all-by-user-id/{id}")]
//        public async Task<ActionResult<Profile>> GealAllByUserId(int id)
//        {
//            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
//            if (user == null)
//            {
//                return BadRequest("The user does not exist.");
//            }
//            return Ok(user.Profile);
//        }

//        [HttpGet("get-by-username/{username}")]
//        public async Task<ActionResult<Profile>> GetById(string username)
//        {
//            Profile? profile = await _context.Profiles.FirstOrDefaultAsync(el => el.Username == username);
//            if (animal == null)
//            {
//                return BadRequest("The user does not exist.");
//            }
//            return Ok(profile);
//        }

//        [HttpPost("add")]
//        public async Task<ActionResult<Animal>> Add(AnimalAddRequest request)
//        {
//            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == request.UserId);
//            if (user == null)
//            {
//                return BadRequest("The user does not exist.");
//            }
//            AnimalType? type = await _context.AnimalTypes.FirstOrDefaultAsync(el => el.Id == request.AnimalTypeId);
//            if (type == null)
//            {
//                return BadRequest("The type does not exist.");
//            }
//            Animal animal = new()
//            {
//                Name = request.Name,
//                Description = request.Description,
//                Age = request.Age,
//                Type = type,
//                AvatarImage = request.AvatarImage,
//                User = user,
//            };
//            user.Animals.Add(animal);
//            await _context.SaveChangesAsync();
//            return Ok(animal);
//        }

//        [HttpDelete("delete-by-id/{id}")]
//        public async Task<ActionResult> DeleteById(int id)
//        {
//            Animal? animal = await _context.Animals.FirstOrDefaultAsync(el => el.Id == id);
//            if (animal == null)
//            {
//                return BadRequest("The animal does not exist.");
//            }
//            _context.Remove(animal);
//            await _context.SaveChangesAsync();
//            return Ok();
//        }
//    }
//}
