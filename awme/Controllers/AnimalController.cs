using awme.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly DataContext _context;
        public AnimalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Animal> animals = _context.Animals.ToList();
            return Ok(animals);
        }
    }
}
