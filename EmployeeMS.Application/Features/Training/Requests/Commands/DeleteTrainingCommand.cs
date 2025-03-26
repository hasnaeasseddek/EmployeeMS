using MediatR;

namespace EmployeeMS.Application.Features.Training.Requests.Commands
{
    public class DeleteTrainingCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
