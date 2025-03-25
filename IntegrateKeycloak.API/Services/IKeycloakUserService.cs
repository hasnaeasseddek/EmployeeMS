namespace IntegrateKeycloak.API.Services
{
    public interface IKeycloakUserService
    {
        Task<List<KeycloakUser>> GetUsers();
        Task<bool> CreateUserWithRole(UserCreationDto newUser, string roleName);
        Task<bool> UpdateUser(string userId, KeycloakUser user);
        Task<bool> DeleteUser(string userId);
    }
}
