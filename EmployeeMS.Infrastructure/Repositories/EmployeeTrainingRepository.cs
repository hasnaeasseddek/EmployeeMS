using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class EmployeeTrainingRepository : GenericRepository<EmployeeTraining>, IEmployeeTrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeTrainingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
