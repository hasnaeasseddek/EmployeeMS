using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Contract
{
    public class UpdateContractDto : BaseDTO, IContractDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; }
    }
}
