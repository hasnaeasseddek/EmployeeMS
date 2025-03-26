using MediatR;

namespace EmployeeMS.Application.Features.Position.Requests.Commands
{
    public class DeletePositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
