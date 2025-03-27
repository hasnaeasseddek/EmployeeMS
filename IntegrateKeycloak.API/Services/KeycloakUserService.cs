//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Text;
//using System.Runtime;
//using static System.Net.WebRequestMethods;

//namespace IntegrateKeycloak.API.Services
//{
//    public class KeycloakUserService : IKeycloakUserService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string _baseUrl = "http://localhost:8080/admin/realms/Poject_test/users";
//        private readonly string _adminToken;
//        private readonly IEmailService _emailService;

//        public KeycloakUserService(HttpClient httpClient, IEmailService emailService)
//        {
//            _httpClient = httpClient;
//            _adminToken = GetAdminToken().Result; //  Idéalement, stocke-le en cache pour éviter d'appeler Keycloak à chaque requête.
//            _emailService = emailService;
//        }

//        private async Task<string> GetAdminToken()
//        {
//            var contentt = new FormUrlEncodedContent(new[]
//            {
//        new KeyValuePair<string, string>("client_id", "mvc-client"),
//        new KeyValuePair<string, string>("client_secret", "3ZieeWjs2zpvIAm6mfNP57WTEaad2Vsj"),
//        new KeyValuePair<string, string>("grant_type", "client_credentials")
//    });

//            var response = await _httpClient.PostAsync(
//                "http://localhost:8080/realms/Poject_test/protocol/openid-connect/token",
//                contentt);

//            if (!response.IsSuccessStatusCode)
//                throw new Exception("Impossible d'obtenir le token d'administration");

//            var content = await response.Content.ReadAsStringAsync();
//            var tokenResponse = JsonSerializer.Deserialize<KeycloakTokenResponse>(content);

//            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken))
//                throw new Exception("Réponse invalide de Keycloak");

//            return tokenResponse.AccessToken;
//        }

//        public async Task<List<KeycloakUser>> GetUsers()
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
//            var response = await _httpClient.GetAsync(_baseUrl);

//            if (!response.IsSuccessStatusCode)
//                throw new Exception("Erreur lors de la récupération des utilisateurs");

//            var content = await response.Content.ReadAsStringAsync();
//            return JsonSerializer.Deserialize<List<KeycloakUser>>(content, new JsonSerializerOptions
//            {
//                PropertyNameCaseInsensitive = true
//            });
//        }

//        public async Task<List<KeycloakUser>> GetUsersWithRoles(string clientId)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

//            // 1️⃣ Récupérer tous les utilisateurs
//            var usersResponse = await _httpClient.GetAsync(_baseUrl);
//            if (!usersResponse.IsSuccessStatusCode)
//                throw new Exception("Erreur lors de la récupération des utilisateurs");

//            var users = JsonSerializer.Deserialize<List<KeycloakUser>>(await usersResponse.Content.ReadAsStringAsync(),
//                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

//            if (users == null || users.Count == 0)
//                return new List<KeycloakUser>(); // Aucun utilisateur trouvé

//            // 2️⃣ Initialiser la liste des utilisateurs avec une liste de rôles vide
//            foreach (var user in users)
//            {
//                user.Roles = new List<RoleDto>();
//            }

//            // 3️⃣ Récupérer tous les rôles du client
//            var rolesResponse = await _httpClient.GetAsync($"http://localhost:8080/admin/realms/Poject_test/clients/{clientId}/roles");
//            if (!rolesResponse.IsSuccessStatusCode)
//                throw new Exception("Erreur lors de la récupération des rôles");

//            var roles = JsonSerializer.Deserialize<List<RoleDto>>(await rolesResponse.Content.ReadAsStringAsync());

//            if (roles == null || roles.Count == 0)
//                return users; // Aucun rôle trouvé, retourner les utilisateurs sans rôle

//            // 4️⃣ Associer les rôles aux utilisateurs
//            foreach (var role in roles)
//            {
//                var roleUsersResponse = await _httpClient.GetAsync(
//                    $"http://localhost:8080/admin/realms/Poject_test/clients/{clientId}/roles/{role.name}/users");

//                if (!roleUsersResponse.IsSuccessStatusCode) continue;

//                var roleUsersJson = await roleUsersResponse.Content.ReadAsStringAsync();
//                if (string.IsNullOrEmpty(roleUsersJson)) continue; // Vérifier si la réponse est vide

//                var roleUsers = JsonSerializer.Deserialize<List<KeycloakUser>>(roleUsersJson,
//    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

//                if (roleUsers == null) continue; // Vérification pour éviter une boucle sur null

//                foreach (var user in roleUsers)
//                {
//                    var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
//                    if (existingUser != null)
//                    {
//                        existingUser.Roles.Add(role); // Ajouter l'objet `RoleDto`
//                    }
//                }
//            }

//            return users;
//        }

//        public async Task<bool> CreateUserWithRole(UserCreationDto newUser, string roleName)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

//            var jsonOptions = new JsonSerializerOptions
//            {
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
//            };

//            // Générer un mot de passe temporaire
//            string temporaryPassword = GenerateRandomPassword();

//            // Ajouter le mot de passe temporaire à l'utilisateur
//            newUser.Credentials = new List<CredentialDto>
//        {
//            new CredentialDto
//            {
//                Type = "password",
//                Value = temporaryPassword,
//                Temporary = true
//            }
//        };

//            var jsonContent = new StringContent(JsonSerializer.Serialize(newUser, jsonOptions), Encoding.UTF8, "application/json");
//            var userResponse = await _httpClient.PostAsync(_baseUrl, jsonContent);

//            if (!userResponse.IsSuccessStatusCode)
//                return false;

//            // Récupérer l'ID de l'utilisateur créé
//            var locationHeader = userResponse.Headers.Location;
//            if (locationHeader == null)
//                return false;

//            string userId = locationHeader.ToString().Split('/').Last();

//            // Assigner le rôle à l'utilisateur
//            bool roleAssigned = await AssignRoleToUser(userId, roleName);
//            if (!roleAssigned)
//                return false;

//            // Envoyer un email avec le mot de passe temporaire
//            string subject = "Votre mot de passe temporaire";
//            string body = $"Bonjour {newUser.FirstName},\n\nVotre compte a été créé avec le rôle '{roleName}'.\nVotre mot de passe temporaire est : {temporaryPassword}\n\nMerci de le modifier après connexion.\n\nCordialement,\nL'équipe.";

//            // await _emailService.SendEmailAsync(newUser.Email, subject, body);

//            return true;
//        }

//        private string GenerateRandomPassword()
//        {
//            return "Temp@1234";
//        }

//        public async Task<bool> UpdateUser(string userId, KeycloakUser user)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
//            var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
//            var response = await _httpClient.PutAsync($"{_baseUrl}/{userId}", jsonContent);
//            return response.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteUser(string userId)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
//            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
//            return response.IsSuccessStatusCode;
//        }

//        public async Task<bool> AssignRoleToUser(string userId, string roleName)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

//            try
//            {
//                string clientUUID = await GetClientUUID("mvc-client"); // Remplace "mvc-client" par ton client_id

//                //  Récupérer le rôle du client
//                var getRoleResponse = await _httpClient.GetAsync($"http://localhost:8080/admin/realms/Poject_test/clients/{clientUUID}/roles/{roleName}");
//                if (!getRoleResponse.IsSuccessStatusCode)
//                {
//                    //Console.WriteLine($"Rôle '{roleName}' non trouvé pour le client '{clientId}'.");
//                    return false;
//                }

//                var roleContent = await getRoleResponse.Content.ReadAsStringAsync();
//                var role = JsonSerializer.Deserialize<RoleDto>(roleContent);
//                if (role == null)
//                {
//                    Console.WriteLine("Impossible de désérialiser le rôle.");
//                    return false;
//                }

//                // 3️ Assigner le rôle à l'utilisateur
//                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
//                var assignRoleJson = new StringContent(JsonSerializer.Serialize(new[] { role }, jsonOptions), Encoding.UTF8, "application/json");

//                var assignRoleResponse = await _httpClient.PostAsync(
//                    $"http://localhost:8080/admin/realms/Poject_test/users/{userId}/role-mappings/clients/{clientUUID}",
//                    assignRoleJson
//                );

//                if (!assignRoleResponse.IsSuccessStatusCode)
//                {
//                    Console.WriteLine($"Erreur lors de l'assignation du rôle : {assignRoleResponse.ReasonPhrase}");
//                }

//                return assignRoleResponse.IsSuccessStatusCode;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception : {ex.Message}");
//                return false;
//            }
//        }

//        private async Task<string> GetClientUUID(string clientId)
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);

//            var response = await _httpClient.GetAsync("http://localhost:8080/admin/realms/Poject_test/clients");
//            if (!response.IsSuccessStatusCode)
//                throw new Exception("Erreur lors de la récupération des clients Keycloak");

//            var content = await response.Content.ReadAsStringAsync();
//            var clients = JsonSerializer.Deserialize<List<ClientDto>>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

//            var client = clients?.FirstOrDefault(c => c.ClientId == clientId);
//            return client?.Id ?? throw new Exception($"Client '{clientId}' non trouvé");
//        }

//        public class ClientDto
//        {
//            public string Id { get; set; } // L'UUID du client
//            public string ClientId { get; set; } // Le nom unique du client
//        }
//    }
//}

using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace IntegrateKeycloak.API.Services
{
    public class KeycloakUserService : IKeycloakUserService
    {
        private readonly HttpClient _httpClient;
        private readonly KeycloakSettings _keycloakSettings;
        private readonly string _token;
        private readonly string _clientUUID;

        public KeycloakUserService(HttpClient httpClient, IOptions<KeycloakSettings> keycloakOptions)
        {
            _httpClient = httpClient;
            _keycloakSettings = keycloakOptions.Value;
            _token = GetAdminTokenAsync().Result;
            _clientUUID = GetClientUUIDAsync().Result;
        }

        public async Task<KeycloakUser?> GetUserByIdAsync(string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users/{userId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KeycloakUser>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<string> GetAdminTokenAsync()
        {
            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("client_id", _keycloakSettings.ClientId),
            new KeyValuePair<string, string>("client_secret", _keycloakSettings.ClientSecret),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

            var response = await _httpClient.PostAsync($"{_keycloakSettings.BaseUrl}/realms/{_keycloakSettings.Realm}/protocol/openid-connect/token", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Impossible d'obtenir le token d'administration");

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<KeycloakTokenResponse>(json);

            return tokenResponse?.AccessToken ?? throw new Exception("Token non valide");
        }

        public async Task<List<KeycloakUser>> GetUsersAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erreur lors de la récupération des utilisateurs");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KeycloakUser>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<KeycloakUser>();
        }

        public async Task<List<KeycloakUser>> GetUsersWithRolesAsync()
        {
            var users = await GetUsersAsync();
            foreach (var user in users) user.Roles = new List<RoleDto>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var rolesResponse = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles");

            if (!rolesResponse.IsSuccessStatusCode) return users;

            var roles = JsonSerializer.Deserialize<List<RoleDto>>(await rolesResponse.Content.ReadAsStringAsync());
            if (roles == null || roles.Count == 0) return users;

            foreach (var role in roles)
            {
                var roleUsersResponse = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles/{role.name}/users");
                if (!roleUsersResponse.IsSuccessStatusCode) continue;

                var roleUsersJson = await roleUsersResponse.Content.ReadAsStringAsync();
                var roleUsers = JsonSerializer.Deserialize<List<KeycloakUser>>(roleUsersJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (roleUsers == null) continue;

                foreach (var user in roleUsers)
                {
                    var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                    if (existingUser != null) existingUser.Roles.Add(role);
                }
            }

            return users;
        }

        private string GenerateTemporaryPassword()
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var password = new char[10]; // Taille entre 8 et 12 caractères

            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[password.Length];

            rng.GetBytes(bytes);

            for (int i = 0; i < password.Length; i++)
            {
                password[i] = validChars[bytes[i] % validChars.Length];
            }

            return new string(password);
        }

        public async Task<bool> CreateUserWithRoleAsync(UserCreationDto newUser, string roleName)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            string tempPassword = GenerateTemporaryPassword();
            newUser.Credentials = new List<CredentialDto> { new() { Type = "password", Value = tempPassword, Temporary = true } };
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(newUser, jsonOptions), Encoding.UTF8, "application/json");
            var userResponse = await _httpClient.PostAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users", jsonContent);

            if (!userResponse.IsSuccessStatusCode) return false;

            var userId = userResponse.Headers.Location?.ToString().Split('/').Last();
            return userId != null && await AssignRoleToUserAsync(userId, roleName);
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto updatedUser)
        {
            if (string.IsNullOrWhiteSpace(updatedUser.Id))
                throw new ArgumentException("L'ID de l'utilisateur est requis.");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(updatedUser, jsonOptions), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users/{updatedUser.Id}", jsonContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.DeleteAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users/{userId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var getRoleResponse = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles/{roleName}");

            if (!getRoleResponse.IsSuccessStatusCode) return false;

            var role = JsonSerializer.Deserialize<RoleDto>(await getRoleResponse.Content.ReadAsStringAsync());
            if (role == null) return false;

            var assignRoleJson = new StringContent(JsonSerializer.Serialize(new[] { role }), Encoding.UTF8, "application/json");
            var assignRoleResponse = await _httpClient.PostAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/users/{userId}/role-mappings/clients/{_clientUUID}", assignRoleJson);

            return assignRoleResponse.IsSuccessStatusCode;
        }

        private async Task<string> GetClientUUIDAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erreur lors de la récupération des clients Keycloak");

            var clientsJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Clients reçus de Keycloak : {clientsJson}");
            var clients = JsonSerializer.Deserialize<List<ClientDto>>(clientsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var client = clients?.FirstOrDefault(c => c.ClientId == _keycloakSettings.ClientId);
            if (client == null)
                throw new Exception($"Client '{_keycloakSettings.ClientId}' non trouvé. Vérifiez si l'ID est correct.");

            return client.Id;
        }

        public async Task<bool> CreateRoleAsync(string roleName, string description)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var role = new
            {
                name = roleName,
                description = description
            };
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(role, jsonOptions), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles", jsonContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erreur lors de la création du rôle");

            return true;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _httpClient.GetAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erreur lors de la récupération des rôles");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<RoleDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<RoleDto>();
        }

        public async Task<bool> UpdateRoleAsync(string roleName, string newRoleName, string newDescription)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var roleUpdate = new
            {
                name = newRoleName,
                description = newDescription
            };
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(roleUpdate, jsonOptions), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(
                $"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles/{roleName}",
                jsonContent);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _httpClient.DeleteAsync($"{_keycloakSettings.BaseUrl}/admin/realms/{_keycloakSettings.Realm}/clients/{_clientUUID}/roles/{roleName}");

            return response.IsSuccessStatusCode;
        }
    }
}