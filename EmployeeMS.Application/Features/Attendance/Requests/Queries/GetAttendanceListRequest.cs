using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;

namespace EmployeeMS.Application.Features.Attendance.Requests.Queries
{
    public class GetAttendanceListRequest : IRequest<List<GetListAllAttendanceDto>>
    {
    }
}
