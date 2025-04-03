using EmployeeMS.Shared.DTOs.Role;

namespace EmployeeMS.MVC.Services
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRolesAsync();
    }

}
