using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class UpdateDepartmentDto : BaseDTO, IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
