using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class InternshipApplicationRepository : GenericRepository<InternshipApplication>, IInternshipApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InternshipApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task UpdateStatus(string status, InternshipApplication internship)
        {
            //internship.Status = status;
            //_dbContext.Entry(internship).State = EntityState.Modified;
        }
    }
}
