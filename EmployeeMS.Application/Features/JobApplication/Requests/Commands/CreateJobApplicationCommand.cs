using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobApplication;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class CreateJobApplicationCommand : IRequest<BaseCommandResponse>
    {
        public CreateJobApplicationDto CreateJobApplicationDto { get; set; }
    }
}
