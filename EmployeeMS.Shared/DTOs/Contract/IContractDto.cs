namespace EmployeeMS.Shared.DTOs.Contract
{
    public interface IContractDto
    {
        int EmployeeId { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        decimal Salary { get; set; }
        string ContractType { get; set; }
    }
}
