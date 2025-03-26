using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Contract
{
    public class GetContractDetailsDto : BaseDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; }
    }
}
