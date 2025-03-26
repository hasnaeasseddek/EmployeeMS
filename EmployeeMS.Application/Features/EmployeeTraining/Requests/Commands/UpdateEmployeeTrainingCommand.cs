using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands
{
    public class UpdateEmployeeTrainingCommand : IRequest<BaseCommandResponse>
    {
        public UpdateEmployeeTrainingDto UpdateEmployeeTrainingDto { get; set; }
    }
}
