using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Contracts.Persistence
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
        Task<GetJobApplicationDetailsDto> GetJobApplicationDetails();
        Task UpdateStatus(string status, JobApplication jobApplication);

    }
}
