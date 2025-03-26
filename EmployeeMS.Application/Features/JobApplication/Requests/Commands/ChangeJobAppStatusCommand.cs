using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.Enums;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class ChangeJobAppStatusCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public ApplicationStatus status { get; set; }

    }
}
