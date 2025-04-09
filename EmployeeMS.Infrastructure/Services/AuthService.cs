using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Interfaces;
using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepo, IRoleRepository roleRepo, IPasswordHasher<User> hasher, IConfiguration config)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _hasher = hasher;
            _config = config;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var roles = await _roleRepo.GetByIdsAsync(dto.RoleIds);
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = _hasher.HashPassword(null!, dto.Password),
                Roles = roles
            };

            await _userRepo.AddAsync(user);
        }

        public async Task<AuthResultDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var token = GenerateJwtToken(user);
            return new AuthResultDto { Token = token, Username = user.Username };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };

            foreach (var role in user.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role.Name));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
