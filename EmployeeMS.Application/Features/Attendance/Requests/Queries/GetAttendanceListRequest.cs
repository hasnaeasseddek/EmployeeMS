using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Requests.Queries
{
    public class GetAttendanceListRequest : IRequest<List<GetListAllAttendanceDto>>
    {
    }
}
