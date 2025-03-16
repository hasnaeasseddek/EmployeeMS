using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Administrateur")]
    public class AdminController : ControllerBase
    {
        [HttpGet("dashboard")]
        public IActionResult GetAdminData()
        {
            return Ok(new { Message = "Bienvenue Administrateur" });
        }
    }
}
