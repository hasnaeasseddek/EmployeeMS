using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Training;
using MediatR;

namespace EmployeeMS.Application.Features.Training.Requests.Commands
{
    public class UpdateTrainingCommand : IRequest<BaseCommandResponse>
    {
        public UpdateTrainingDto UpdateTrainingDto { get; set; }
    }
}
