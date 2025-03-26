using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class GetListAllDepartmentDto : BaseDTO
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
    }
}
