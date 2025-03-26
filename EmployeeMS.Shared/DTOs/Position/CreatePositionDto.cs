namespace EmployeeMS.Shared.DTOs.Position
{
    public class CreatePositionDto : IPositionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal BaseSalary { get; set; }
    }
}
