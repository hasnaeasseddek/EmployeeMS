using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto
    {
        int EmployeeId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string LeaveType { get; set; }
        string Reason { get; set; }
    }
}
