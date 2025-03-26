using MediatR;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands
{
    public class DeleteEmployeeTrainingCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
