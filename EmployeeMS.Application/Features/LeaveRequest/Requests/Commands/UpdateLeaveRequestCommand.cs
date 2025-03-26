using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;

namespace EmployeeMS.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
    }
}
