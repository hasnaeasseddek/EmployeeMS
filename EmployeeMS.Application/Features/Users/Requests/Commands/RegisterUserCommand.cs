using EmployeeMS.Shared.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Users.Requests.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserDto Dto { get; set; }
        public RegisterUserCommand(RegisterUserDto dto) => Dto = dto;
    }

}
