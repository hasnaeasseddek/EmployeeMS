using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(Roles = "Utilisateur")]
    public class UserController : ControllerBase
    {
        [HttpGet("dashboard")]
        public IActionResult GetUserData()
        {
            return Ok(new { Message = "Bienvenue Utilisateur" });
        }
    }
}
