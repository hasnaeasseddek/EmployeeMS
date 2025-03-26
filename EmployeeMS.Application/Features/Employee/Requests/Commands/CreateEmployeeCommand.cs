using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Requests.Commands
{
    public class CreateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; set; }
    }
}
