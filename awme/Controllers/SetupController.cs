using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace awme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetupController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public SetupController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager= roleManager;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok();
        }

    }
}
