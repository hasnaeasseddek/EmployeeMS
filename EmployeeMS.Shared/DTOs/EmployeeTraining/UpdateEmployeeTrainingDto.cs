using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.EmployeeTraining
{
    public class UpdateEmployeeTrainingDto : BaseDTO, IEmployeeTrainingDto
    {
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime CertificationDate { get; set; }
        public string CertificateUrl { get; set; }
    }
}
