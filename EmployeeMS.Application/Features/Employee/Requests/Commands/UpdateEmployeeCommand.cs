using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Requests.Commands
{
    public class UpdateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public UpdateEmployeeDto UpdateEmployeeDto { get; set; }
    }
}
