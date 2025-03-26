namespace EmployeeMS.Shared.DTOs.Position
{
    public interface IPositionDto
    {
        string Title { get; set; }
        string Description { get; set; }
        decimal BaseSalary { get; set; }
    }
}
