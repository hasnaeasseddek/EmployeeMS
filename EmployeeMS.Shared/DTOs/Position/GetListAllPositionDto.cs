using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Position
{
    public class GetListAllPositionDto : BaseDTO
    {
        public string Title { get; set; }
        public decimal BaseSalary { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
