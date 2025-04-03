namespace IntegrateKeycloak.API.Services
{
    public class UpdateUserRolesDto
    {
        public string UserId { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }

}
