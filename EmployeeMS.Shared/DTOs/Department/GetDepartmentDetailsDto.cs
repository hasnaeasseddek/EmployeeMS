using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class GetDepartmentDetailsDto : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeCount { get; set; }
    }
}
