using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Employee
{
    public class GetListAllEmployeeDto : BaseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string PositionTitle { get; set; }
        public DateTime DateHired { get; set; }
    }
}
