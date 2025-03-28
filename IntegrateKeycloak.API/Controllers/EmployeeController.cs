using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize(Policy = "create_employee")]
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(string employee)
        {
            // Code pour créer l'employé
        }

    }
}
