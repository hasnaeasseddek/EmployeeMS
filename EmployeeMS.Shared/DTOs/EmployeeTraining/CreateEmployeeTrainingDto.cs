namespace EmployeeMS.Shared.DTOs.EmployeeTraining
{
    public class CreateEmployeeTrainingDto : IEmployeeTrainingDto
    {
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime CertificationDate { get; set; }
        public string CertificateUrl { get; set; }
    }
}
