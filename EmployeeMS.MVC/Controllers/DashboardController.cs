using EmployeeMS.MVC.Models;
using EmployeeMS.MVC.Services;
using EmployeeMS.Shared.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace EmployeeMS.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly KeycloakUserService _userService;
        private readonly HttpClient _httpClient;

        public DashboardController(KeycloakUserService userService, HttpClient httpClient)
        {
            _userService = userService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            List<KeycloakUser> users = await _userService.GetUsersAsync();

            var model = new DashboardViewModel
            {
                TotalUsers = users.Count,
                AdminsCount = users.Count(u => u.Roles.Any(r => r.name == "admin" || r.name == "Administrateur")),
                EmployeesCount = users.Count(u => u.Roles.Any(r => r.name == "employe")),
                VisitorsCount = users.Count(u => u.Roles.Any(r => r.name == "visitor")),
                Users = users
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromQuery] string role, [FromBody] UserCreationDto user)
        {
            if (string.IsNullOrEmpty(role) || user == null)
            {
                return BadRequest("Données invalides.");
            }

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"https://localhost:7034/api/KeycloakUser?role={role}", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Utilisateur ajouté avec succès.");
            }
            else
            {
                return BadRequest("Erreur lors de l'ajout de l'utilisateur.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = $"https://localhost:7034/api/KeycloakUser/{id}";
                var response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return BadRequest("Erreur lors de la suppression.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto user)
        {
            Console.WriteLine($"Reçu : Id={user.Id}, FirstName={user.FirstName}, LastName={user.LastName}, Email={user.Email}, Enabled={user.Enabled}");

            using (var client = new HttpClient())
            {
                string apiUrl = "https://localhost:7034/api/KeycloakUser";
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return BadRequest("Erreur lors de la mise à jour.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesDto userRoles)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = "https://localhost:7034/api/KeycloakUser/users/roles";
                var json = JsonSerializer.Serialize(userRoles);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return BadRequest("Erreur lors de la mise à jour des rôles.");
            }
        }


    }
}
