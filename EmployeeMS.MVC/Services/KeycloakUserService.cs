using EmployeeMS.Shared.DTOs.Users;
using System.Text.Json;

namespace EmployeeMS.MVC.Services
{
    public class KeycloakUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7034/api/KeycloakUser";

        public KeycloakUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KeycloakUser>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new List<KeycloakUser>(); // Return empty list if error
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KeycloakUser>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
