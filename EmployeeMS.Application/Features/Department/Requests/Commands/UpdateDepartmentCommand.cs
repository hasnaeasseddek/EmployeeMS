using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;

namespace EmployeeMS.Application.Features.Department.Requests.Commands
{
    public class UpdateDepartmentCommand : IRequest<BaseCommandResponse>
    {
        public UpdateDepartmentDto UpdateDepartmentDto { get; set; }
    }
}
