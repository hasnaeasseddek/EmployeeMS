using EmployeeMS.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(LoginDto dto);
        Task RegisterAsync(RegisterUserDto dto);
    }

}
