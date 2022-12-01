using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Migrations;
using awme.Services.AnimalTypeServices;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalTypeController : Controller
    {
        private readonly IAnimalTypeService _animalTypeService;
        public AnimalTypeController(IAnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<AnimalType>>> GetAll()
        {
            List<AnimalType> types = await _animalTypeService.GetTypes();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> Get(int id)
        {
            AnimalType? type = await _animalTypeService.GetType(id);
            if (type == null)
            {
                return NotFound("Animal type does not exist.");
            }
            return Ok(type);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<AnimalType>> Add(string type)
        {
            if (await _animalTypeService.CheckIfTypeExists(type))
            {
                return StatusCode(409, "The type already exists.");
            }
            var animalType = await _animalTypeService.AddType(type);
            return CreatedAtAction(nameof(Get), new { id = animalType.Id }, animalType);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (!await _animalTypeService.DeleteType(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
