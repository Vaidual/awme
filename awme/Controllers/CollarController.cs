using awme.Data.Dto.Collar;
using awme.Data.Models;
using awme.Services.AnimalTypeServices;
using awme.Services.CollarServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [Route("api/collars")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CollarController : Controller
    {
        private readonly ICollarService _collarService;

        public CollarController(ICollarService collarService)
        {
            this._collarService = collarService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CollarGetRequest>>> GetAll()
        {
            List<CollarGetRequest> collars = await _collarService.GetCollars();
            return Ok(collars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collar>> Get(string id)
        {
            Collar? collar = await _collarService.GetCollar(id);
            if (collar == null)
            {
                return NotFound("Collar does not exist.");
            }
            return Ok(collar);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Collar>> Add([FromBody] string deviceId)
        {
            if (await _collarService.CheckIfCollarExists(deviceId))
            {
                return StatusCode(409, "The collar already exists.");
            }
            var collar = await _collarService.AddCollar(deviceId);
            return CreatedAtAction(nameof(Get), new { id = collar.Id }, collar);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteById(string id)
        {
            if (!await _collarService.DeleteCollar(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
