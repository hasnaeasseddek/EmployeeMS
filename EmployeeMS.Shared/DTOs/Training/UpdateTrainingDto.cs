using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Training
{
    public class UpdateTrainingDto : BaseDTO, ITrainingDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
