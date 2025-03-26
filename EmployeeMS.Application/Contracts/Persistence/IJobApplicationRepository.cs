using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.JobApplications;

namespace EmployeeMS.Application.Contracts.Persistence
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
        Task<GetJobApplicationDetailsDto> GetJobApplicationDetails();
        Task UpdateStatus(string status, JobApplication jobApplication);

    }
}
