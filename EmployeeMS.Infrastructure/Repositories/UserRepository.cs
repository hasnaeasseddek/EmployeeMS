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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Roles)
                                       .ThenInclude(r => r.Permissions)
                                       .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }

}
