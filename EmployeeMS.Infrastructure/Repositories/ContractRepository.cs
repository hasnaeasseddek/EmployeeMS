using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        private readonly ApplicationDbContext _context;

        public ContractRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
