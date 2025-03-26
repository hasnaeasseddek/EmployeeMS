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
