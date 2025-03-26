using MediatR;

namespace EmployeeMS.Application.Features.Department.Requests.Commands
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
