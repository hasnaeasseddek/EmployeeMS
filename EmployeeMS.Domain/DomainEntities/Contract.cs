using EmployeeMS.Shared.Enums;

namespace EmployeeMS.Domain.DomainEntities
{
    public class Contract : BaseDomainEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }
        public ContractType ContractType { get; set; } = ContractType.CDI;// Example: CDI, CDD, Internship
    }
}
