using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Requests.Commands
{
    public class DeleteAttendanceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
