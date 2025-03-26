using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Position;
using MediatR;

namespace EmployeeMS.Application.Features.Position.Requests.Commands
{
    public class CreatePositionCommand : IRequest<BaseCommandResponse>
    {
        public CreatePositionDto CreatePositionDto { get; set; }
    }
}
