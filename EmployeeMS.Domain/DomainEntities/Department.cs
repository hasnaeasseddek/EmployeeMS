namespace EmployeeMS.Domain.DomainEntities
{
    public class Department : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
