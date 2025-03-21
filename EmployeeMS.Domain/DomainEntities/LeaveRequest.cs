using EmployeeMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Domain.DomainEntities
{
    public class LeaveRequest : BaseDomainEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; } = LeaveType.PaidLeave; // Example: Paid, Sick, etc.
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending; // Pending, Approved, Rejected
        public string Reason { get; set; }
    }
}
