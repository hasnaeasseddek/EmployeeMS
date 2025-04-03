using EmployeeMS.Shared.DTOs.Role;
using System.Diagnostics;
using System.Text.Json;

namespace EmployeeMS.MVC.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<RoleDto>>("https://localhost:7034/api/KeycloakRole");
        }
    }

}
