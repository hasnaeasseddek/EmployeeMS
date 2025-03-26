using MediatR;

namespace EmployeeMS.Application.Features.Attendance.Requests.Commands
{
    public class DeleteAttendanceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
