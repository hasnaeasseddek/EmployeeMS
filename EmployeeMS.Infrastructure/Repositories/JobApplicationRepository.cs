using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class JobApplicationRepository : GenericRepository<JobApplication> , IJobApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public JobApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public Task<GetJobApplicationDetailsDto> GetJobApplicationDetails()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatus(string status, JobApplication jobApplication)
        {
            throw new NotImplementedException();
        }
    }
}
