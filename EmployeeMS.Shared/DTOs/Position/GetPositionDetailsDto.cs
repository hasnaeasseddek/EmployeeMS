using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Position
{
    public class GetPositionDetailsDto : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal BaseSalary { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
