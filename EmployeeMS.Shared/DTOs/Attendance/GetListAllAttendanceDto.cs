using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.Attendance
{
    public class GetListAllAttendanceDto : BaseDTO
    {
        public string EmployeeFullName { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public double HoursWorked { get; set; }
    }
}
