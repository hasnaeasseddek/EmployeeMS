using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Users.Requests.Commands;
using EmployeeMS.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Users.Handlers.Commands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IPasswordHasher<User> _hasher;

        public RegisterUserHandler(IUserRepository userRepo, IRoleRepository roleRepo, IPasswordHasher<User> hasher)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _hasher = hasher;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepo.GetByIdsAsync(request.Dto.RoleIds);
            var user = new User
            {
                Username = request.Dto.Username,
                PasswordHash = _hasher.HashPassword(null!, request.Dto.Password),
                Roles = roles
            };

            await _userRepo.AddAsync(user);
            return Unit.Value;
        }
    }

}
