using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;

namespace EmployeeMS.Application.Features.Department.Requests.Commands
{
    public class CreateDepartmentCommand : IRequest<BaseCommandResponse>
    {
        public CreateDepartmentDto CreateDepartmentDto { get; set; }
    }
}
