namespace EmployeeMS.Domain.DomainEntities
{
    public class EmployeeTraining : BaseDomainEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public DateTime CertificationDate { get; set; }
        public string CertificateUrl { get; set; }
    }
}
