using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Role>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Roles
                .Include(r => r.Permissions)
                .Where(r => ids.Contains(r.Id))
                .ToListAsync();
        }
    }

}
