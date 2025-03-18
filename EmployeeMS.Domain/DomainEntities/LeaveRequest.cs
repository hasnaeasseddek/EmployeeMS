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
        public string LeaveType { get; set; } // Example: Paid, Sick, etc.
        public string Status { get; set; } // Pending, Approved, Rejected
        public string Reason { get; set; }
    }
}
