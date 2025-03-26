using MediatR;

namespace EmployeeMS.Application.Features.Employee.Requests.Commands
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
