using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Requests.Commands
{
    public class CreateDepartmentCommand : IRequest<BaseCommandResponse>
    {
        public CreateDepartmentDto CreateDepartmentDto { get; set; }
    }
}
