namespace EmployeeMS.Domain.DomainEntities
{
    public class Position : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal BaseSalary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
