using EmployeeMS.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace EmployeeMS.MVC.Controllers
{
    public class RolesController : Controller
    {

        
        //[HttpPost]
        //public async Task<IActionResult> AddRole([FromBody] RoleCreationDto role)
        //{
        //    if (role == null)
        //    {
        //        return BadRequest("Données invalides.");
        //    }

        //    var json = JsonSerializer.Serialize(role);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync("https://localhost:7034/api/KeycloakRole", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return Ok("Rôle ajouté avec succès.");
        //    }
        //    else
        //    {
        //        return BadRequest("Erreur lors de l'ajout du rôle.");
        //    }
        //}
    }

}
