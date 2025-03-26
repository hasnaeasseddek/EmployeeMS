using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public JobOfferRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
