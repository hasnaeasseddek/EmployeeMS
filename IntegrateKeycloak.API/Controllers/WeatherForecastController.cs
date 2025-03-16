using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Authorize] // Prot�g�, n�cessite un token
        public IActionResult Get()
        {
            return Ok(new { message = "Acc�s autoris� � l�API !" });
        }
    }
}
