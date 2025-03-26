using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Application.Contracts.Persistence
{
    public interface IInternshipApplicationRepository : IGenericRepository<InternshipApplication>
    {
        Task UpdateStatus(string status, InternshipApplication internship);
    }
}
