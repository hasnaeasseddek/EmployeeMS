namespace EmployeeMS.Shared.DTOs.Training
{
    public interface ITrainingDto
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
