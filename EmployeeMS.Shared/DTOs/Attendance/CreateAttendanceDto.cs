namespace EmployeeMS.Shared.DTOs.Attendance
{
    public class CreateAttendanceDto : IAttendanceDto
    {
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public double HoursWorked { get; set; }
    }
}
