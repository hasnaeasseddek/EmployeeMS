using IntegrateKeycloak.API.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailS _emailS;

        public EmailsController(IEmailS emailS)
        {
            _emailS = emailS;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailsAsync(string receptor, string subject,string body)
        {
             await _emailS.SendEmail(receptor, subject, body);
            return Ok();
        }
    }
}
