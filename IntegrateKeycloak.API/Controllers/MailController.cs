using IntegrateKeycloak.API.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        Services.EmailService.IMailService Mail_Service = null;
        //injecting the IMailService into the constructor
        public MailController(Services.EmailService.IMailService _MailService)
        {
            Mail_Service = _MailService;
        }
        [HttpPost]
        public bool SendMail(Services.EmailService.MailData Mail_Data)
        {
            return Mail_Service.SendMail(Mail_Data);
        }
    }
}
