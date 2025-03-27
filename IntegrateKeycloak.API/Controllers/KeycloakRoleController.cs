using IntegrateKeycloak.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrateKeycloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeycloakRoleController : ControllerBase
    {
        private readonly IKeycloakUserService _keycloakUserService;

        public KeycloakRoleController(IKeycloakUserService keycloakUserService)
        {
            _keycloakUserService = keycloakUserService;
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _keycloakUserService.GetRolesAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Update a role
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateRole(string roleName, string newRoleName, string newDescription)
        {
            var success = await _keycloakUserService.UpdateRoleAsync(roleName, newRoleName,newDescription);
            if (!success) return BadRequest("Failed to update role");
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateRole(string roleName, string description)
        {
            var role =  await _keycloakUserService.CreateRoleAsync(roleName, description);
            return Ok(role);
            
        }

        /// <summary>
        /// Delete a role
        /// </summary>
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var success = await _keycloakUserService.DeleteRoleAsync(roleName);
            if (!success) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Assign a role to a user
        /// </summary>
        [HttpPost("{userId}/assign-role/{roleName}")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            var success = await _keycloakUserService.AssignRoleToUserAsync(userId, roleName);
            if (!success) return BadRequest("Failed to assign role");
            return Ok("Role assigned successfully");
        }
    }
}
