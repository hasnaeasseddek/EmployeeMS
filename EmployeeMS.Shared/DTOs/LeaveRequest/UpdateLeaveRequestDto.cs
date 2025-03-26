using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDTO, ILeaveRequestDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
