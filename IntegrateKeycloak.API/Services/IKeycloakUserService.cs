namespace IntegrateKeycloak.API.Services
{
    public interface IKeycloakUserService
    {
        Task<List<KeycloakUser>> GetUsersAsync();
        Task<List<KeycloakUser>> GetUsersWithRolesAsync(string clientId);
        Task<bool> CreateUserWithRoleAsync(UserCreationDto newUser, string roleName);
        Task<bool> UpdateUserAsync(string userId, KeycloakUser user);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        //Task<List<KeycloakUser>> GetUsers();

        //Task<bool> CreateUserWithRole(UserCreationDto newUser, string roleName);

        //Task<bool> UpdateUser(string userId, KeycloakUser user);

        //Task<bool> DeleteUser(string userId);

        //Task<bool> AssignRoleToUser(string userId, string roleName);

        //Task<List<KeycloakUser>> GetUsersWithRoles(string clientId);
    }
}