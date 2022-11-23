using awme.Data.Dto.User;
using awme.Data.Models;
using awme.Migrations;
using awme.Services.AnimalTypeService;
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
        private readonly IConfiguration _configuration;
        public AnimalTypeController(IAnimalTypeService animalTypeService, IConfiguration configuration)
        {
            _animalTypeService = animalTypeService;
            _configuration = configuration;
        }

        [HttpGet()]
        public async Task<ActionResult<List<AnimalType>>> GetAll()
        {
            List<AnimalType> types = await _animalTypeService.GetTypes();
            return Ok(types);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<AnimalType>> Add(string type)
        {
            if (await _animalTypeService.CheckIfTypeExists(type))
            {
                return BadRequest("The type already exists.");
            }
            var animalType = await _animalTypeService.AddType(type);
            return Ok(CreatedAtAction(nameof(GetAll), new { id = animalType.Id }, animalType));
        }

        [HttpDelete("delete-by-id/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _animalTypeService.DeleteType(id);
            return Ok();
        }
    }
}
