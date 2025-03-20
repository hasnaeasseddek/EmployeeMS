using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.InternshipApplications
{
    public class GetAllInternshipApplicationsDto : BaseDTO
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string InternshipType { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
