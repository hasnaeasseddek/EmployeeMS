using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Runtime;
using static System.Net.WebRequestMethods;

namespace IntegrateKeycloak.API.Services
{
    public class KeycloakUserService : IKeycloakUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8080/admin/realms/Poject_test/users";
        private readonly string _adminToken;

        public KeycloakUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _adminToken = GetAdminToken().Result; //  Idéalement, stocke-le en cache pour éviter d'appeler Keycloak à chaque requête.
        }

        private async Task<string> GetAdminToken()
        {
            var contentt = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("client_id", "mvc-client"),
        new KeyValuePair<string, string>("client_secret", "3ZieeWjs2zpvIAm6mfNP57WTEaad2Vsj"),
        new KeyValuePair<string, string>("grant_type", "client_credentials")
    });

            var response = await _httpClient.PostAsync(
                "http://localhost:8080/realms/Poject_test/protocol/openid-connect/token",
                contentt);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Impossible d'obtenir le token d'administration");

            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<KeycloakTokenResponse>(content);

            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken))
                throw new Exception("Réponse invalide de Keycloak");

            return tokenResponse.AccessToken;
        }


        public async Task<List<KeycloakUser>> GetUsers()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
            var response = await _httpClient.GetAsync(_baseUrl);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erreur lors de la récupération des utilisateurs");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KeycloakUser>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<bool> CreateUserWithRole(UserCreationDto newUser, string roleName)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(newUser, jsonOptions), Encoding.UTF8, "application/json");
            var userResponse = await _httpClient.PostAsync(_baseUrl, jsonContent);

            if (!userResponse.IsSuccessStatusCode)
                return false;

            // 2️⃣ Récupérer l'ID de l'utilisateur créé
            var getUsersResponse = await _httpClient.GetAsync($"{_baseUrl}/?username={newUser.Username}");
            if (!getUsersResponse.IsSuccessStatusCode)
                return false;

            var usersContent = await getUsersResponse.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<KeycloakUser>>(usersContent);
            var createdUser = users?.FirstOrDefault();

            if (createdUser == null)
                return false;

            // 3️⃣ Vérifier si le rôle existe déjà
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

            var getRolesResponse = await _httpClient.GetAsync($"http://localhost:8080/admin/realms/Poject_test/roles/{roleName}");

            //var getRolesResponse = await _httpClient.GetAsync($"http://localhost:8080/admin/realms/Poject_test/roles/{roleName}");
            if (getRolesResponse.StatusCode == System.Net.HttpStatusCode.NotFound)//403
            {
                var jsonOption = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                var roleData = new
                {
                    name = roleName,
                    description = "Role créé automatiquement",
                    composite = false,
                    clientRole = false,
                    containerId = "Poject_test"
                };
                var roleJson = new StringContent(JsonSerializer.Serialize(roleData, jsonOption), Encoding.UTF8, "application/json");
                // 4️⃣ Créer le rôle si inexistant
                //var roleJson = new StringContent(JsonSerializer.Serialize(new { name = roleName }), Encoding.UTF8, "application/json");
                var createRoleResponse = await _httpClient.PostAsync(
    "http://localhost:8080/admin/realms/Poject_test/roles",
    roleJson);

                var errorResponse = await createRoleResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Erreur création rôle: {errorResponse}");

                if (!createRoleResponse.IsSuccessStatusCode)
                    return false;
            }

            // 5️⃣ Récupérer le rôle avec son ID
            var getNewRoleResponse = await _httpClient.GetAsync($"http://localhost:8080/admin/realms/Poject_test/roles/{roleName}");
            if (!getNewRoleResponse.IsSuccessStatusCode)
                return false;

            var roleContent = await getNewRoleResponse.Content.ReadAsStringAsync();
            var role = JsonSerializer.Deserialize<RoleDto>(roleContent);

            if (role == null)
                return false;

            // 6️⃣ Assigner le rôle à l'utilisateur
            var assignRoleJson = new StringContent(JsonSerializer.Serialize(new[] { role }, jsonOptions), Encoding.UTF8, "application/json");
            var assignRoleResponse = await _httpClient.PostAsync($"{_baseUrl}/{createdUser.Id}/role-mappings/realm", assignRoleJson);

            return assignRoleResponse.IsSuccessStatusCode;
        }



        public async Task<bool> UpdateUser(string userId, KeycloakUser user)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
            var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/{userId}", jsonContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
            return response.IsSuccessStatusCode;
        }
    }
}
