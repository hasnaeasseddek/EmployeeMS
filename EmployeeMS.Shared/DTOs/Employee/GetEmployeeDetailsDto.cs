using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Employee
{
    public class GetEmployeeDetailsDto : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public string PositionTitle { get; set; }
        public DateTime DateHired { get; set; }
    }
}
