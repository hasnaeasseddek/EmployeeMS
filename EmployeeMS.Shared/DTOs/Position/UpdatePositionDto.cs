using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Position
{
    public class UpdatePositionDto : BaseDTO, IPositionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal BaseSalary { get; set; }
    }
}
