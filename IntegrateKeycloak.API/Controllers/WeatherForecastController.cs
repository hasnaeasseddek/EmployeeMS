using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Authorize] // Protégé, nécessite un token
        public IActionResult Get()
        {
            return Ok(new { message = "Accès autorisé à l’API !" });
        }
    }
}
