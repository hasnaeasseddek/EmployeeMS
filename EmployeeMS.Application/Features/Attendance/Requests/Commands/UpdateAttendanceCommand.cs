using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;

namespace EmployeeMS.Application.Features.Attendance.Requests.Commands
{
    public class UpdateAttendanceCommand : IRequest<BaseCommandResponse>
    {
        public UpdateAttendanceDto UpdateAttendanceDto { get; set; }
    }
}
