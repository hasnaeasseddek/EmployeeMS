using EmployeeMS.Shared.Enums;

namespace EmployeeMS.Domain.DomainEntities
{
    public class Attendance : BaseDomainEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public double HoursWorked { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Present;
    }
}
