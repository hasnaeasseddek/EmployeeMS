using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobApplication;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class UpdateJobApplicationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateJobApplicationDto UpdateJobApplicationDto { get; set; }
    }
}
