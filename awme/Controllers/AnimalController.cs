using awme.Data.Dto.Animal;
using awme.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalController : ControllerBase
    {
        private readonly DataContext _context;
        public AnimalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            List<Animal> animals = _context.Animals.ToList();
            return Ok(animals);
        }

        [HttpGet("get-all-by-user-id/{id}")]
        public async Task<ActionResult<List<Animal>>> GealAllByUserId(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == id);
            if (user == null)
            {
                return BadRequest("The user does not exist.");
            }
            return Ok(user.Animals);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Animal>> GetById(int id)
        {
            Animal? animal = await _context.Animals.FirstOrDefaultAsync(el => el.Id == id);
            if (animal == null)
            {
                return BadRequest("The user does not exist.");
            }
            return Ok(animal);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Animal>> Add(AnimalAddRequest request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(el => el.Id == request.UserId);
            if (user == null)
            {
                return BadRequest("The user does not exist.");
            }
            AnimalType? type = await _context.AnimalTypes.FirstOrDefaultAsync(el => el.Id == request.TypeId);
            if (type == null)
            {
                return BadRequest("The type does not exist.");
            }
            Animal animal = new()
            {
                Name = request.Name,
                Description = request.Description,
                Age = request.Age,
                Type = type,
                AvatarImage = request.AvatarImage,
                User = user,
                Gender = request.Gender,
            };
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return Ok(animal); 
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            Animal? animal = await _context.Animals.FirstOrDefaultAsync(el => el.Id == id);
            if (animal == null)
            {
                return BadRequest("The animal does not exist.");
            }
            _context.Remove(animal);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
