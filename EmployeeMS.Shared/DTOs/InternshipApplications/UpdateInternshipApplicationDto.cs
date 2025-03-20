using EmployeeMS.Shared.DTOs.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.InternshipApplications
{
    public class UpdateInternshipApplicationDto : BaseDTO, IInternshipApplicationDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Institution { get; set; }
        public string EducationLevel { get; set; }
        public string Specialization { get; set; }
        public string InternshipType { get; set; }
        public string City { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<IFormFile>? Documents { get; set; }
    }
}