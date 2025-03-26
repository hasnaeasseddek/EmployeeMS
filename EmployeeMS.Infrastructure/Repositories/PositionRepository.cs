using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
