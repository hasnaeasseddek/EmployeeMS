using IntegrateKeycloak.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeycloakUserController : ControllerBase
    {
        private readonly IKeycloakUserService _keycloakUserService;

        public KeycloakUserController(IKeycloakUserService keycloakUserService)
        {
            _keycloakUserService = keycloakUserService;
        }

        [HttpGet]
        public async Task<List<KeycloakUser>> GetUsers(string clientId)
        {
           return await _keycloakUserService.GetUsersWithRolesAsync(clientId);
            ///return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto user, string role)
        {
            var success = await _keycloakUserService.CreateUserWithRoleAsync(user,role);
            if (!success) return BadRequest("Échec de la création de l'utilisateur.");
            return Ok("Utilisateur créé avec succès.");
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] KeycloakUser user)
        {
            var success = await _keycloakUserService.UpdateUserAsync(userId, user);
            if (!success) return BadRequest("Échec de la mise à jour de l'utilisateur.");
            return Ok("Utilisateur mis à jour.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var success = await _keycloakUserService.DeleteUserAsync(userId);
            if (!success) return BadRequest("Échec de la suppression de l'utilisateur.");
            return Ok("Utilisateur supprimé.");
        }
        [HttpPost("{userId}/assign-role")]
        public async Task<IActionResult> AssignRoleToUser(string userId, [FromQuery] string role)
        {
            var success = await _keycloakUserService.AssignRoleToUserAsync(userId, role);
            if (!success) return BadRequest("Échec de l'assignation du rôle.");
            return Ok("Rôle assigné avec succès.");
        }

    }
}