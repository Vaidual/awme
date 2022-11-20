using awme.Data.Dto.User;
using awme.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : Controller
    {
        private readonly DataContext _context;
        public AnimalTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<AnimalType>>> GetAll()
        {
            List<AnimalType> types = await _context.AnimalTypes.ToListAsync();
            return Ok(types);
        }

        [HttpPost("add"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<AnimalType>> Add(string type)
        {
            if (_context.AnimalTypes.Any(el => el.TypeName == type))
            {
                return BadRequest("The type already exists.");
            }
            AnimalType annimalType = new()
            {
                TypeName = type,
            };
            await _context.AnimalTypes.AddAsync(annimalType);
            await _context.SaveChangesAsync();
            return Ok(annimalType);
        }

        [HttpDelete("delete-by-id/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            AnimalType? type = await _context.AnimalTypes.FirstOrDefaultAsync(el => el.Id == id);
            if (type == null)
            {
                return BadRequest("The type does not exist.");
            }
            _context.Remove(type);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
