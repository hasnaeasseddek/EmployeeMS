using System.Data;

namespace IntegrateKeycloak.API.Services
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class RolePermission
    {
        public string RoleId { get; set; } // L'ID du rôle Keycloak
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
    }





}
