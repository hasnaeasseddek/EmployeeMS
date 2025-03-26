using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Training;
using MediatR;

namespace EmployeeMS.Application.Features.Training.Requests.Commands
{
    public class CreateTrainingCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainingDto CreateTrainingDto { get; set; }
    }
}
