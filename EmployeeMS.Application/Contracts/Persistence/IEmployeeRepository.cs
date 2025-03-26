using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
