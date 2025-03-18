using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Attendance
{
    public interface IAttendanceDto
    {
        int EmployeeId { get; set; }
        DateTime CheckInTime { get; set; }
        DateTime? CheckOutTime { get; set; }
        double HoursWorked { get; set; }
    }
}
