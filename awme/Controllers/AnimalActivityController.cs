using awme.Data.Models;
using awme.Services.AnimalActivityServices;
using awme.Services.CollarServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalActivityController : Controller
    {
        private readonly IAnimalActivityService _animalActivityService;

        public AnimalActivityController(IAnimalActivityService animalActivityService)
        {
            this._animalActivityService = animalActivityService;
        }

        [HttpGet("{collarId}")]
        public async Task<ActionResult<List<Activity>>> GetByCollarId(string collarId)
        {
            List<Activity> activities = await _animalActivityService.GetActivity(collarId);
            return Ok(activities);
        }

        [HttpDelete("{id}/{startDate}/{endDate}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(string id, DateOnly startDate, DateOnly endDate)
        {
            await _animalActivityService.DeleteActivity(id, startDate, endDate);
            return NoContent();
        }
    }
}
