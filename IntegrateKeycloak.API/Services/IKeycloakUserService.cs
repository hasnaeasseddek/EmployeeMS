namespace IntegrateKeycloak.API.Services
{
    public interface IKeycloakUserService
    {
        Task<List<KeycloakUser>> GetUsersAsync();
        Task<List<KeycloakUser>> GetUsersWithRolesAsync();
        Task<bool> CreateUserWithRoleAsync(UserCreationDto newUser, string roleName);
        Task<bool> UpdateUserAsync(UpdateUserDto updatedUser);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<KeycloakUser?> GetUserByIdAsync(string userId);
        Task<bool> UpdateRoleAsync(string roleName, string newRoleName, string newDescription);
        Task<bool> CreateRoleAsync(string roleName, string description);
        Task<List<RoleDto>> GetRolesAsync();
        Task<bool> DeleteRoleAsync(string roleId);

        //Task<List<KeycloakUser>> GetUsers();

        //Task<bool> CreateUserWithRole(UserCreationDto newUser, string roleName);

        //Task<bool> UpdateUser(string userId, KeycloakUser user);

        //Task<bool> DeleteUser(string userId);

        //Task<bool> AssignRoleToUser(string userId, string roleName);

        //Task<List<KeycloakUser>> GetUsersWithRoles(string clientId);
    }
}