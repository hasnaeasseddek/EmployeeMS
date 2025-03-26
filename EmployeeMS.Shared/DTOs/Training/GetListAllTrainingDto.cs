using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Training
{
    public class GetListAllTrainingDto : BaseDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public int ParticipantCount { get; set; }
    }
}
