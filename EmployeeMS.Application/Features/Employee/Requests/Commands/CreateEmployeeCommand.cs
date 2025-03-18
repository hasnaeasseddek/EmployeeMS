using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Employee.Requests.Commands
{
    public class CreateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; set; }
    }
}
