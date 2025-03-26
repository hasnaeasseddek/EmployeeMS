using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;

namespace EmployeeMS.Application.Features.Attendance.Requests.Commands
{
    public class CreateAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateAttendanceDto CreateAttendanceDto { get; set; }
    }
}
