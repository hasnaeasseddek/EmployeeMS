using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;

namespace EmployeeMS.Application.Features.Attendance.Requests.Queries
{
    public class GetAttendanceDetailRequest : IRequest<GetAttendanceDetailsDto>
    {
        public int Id { get; set; }
    }
}
