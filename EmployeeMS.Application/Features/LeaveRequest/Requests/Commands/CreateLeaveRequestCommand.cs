using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;

namespace EmployeeMS.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
