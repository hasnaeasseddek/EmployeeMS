using EmployeeMS.Shared.DTOs.Common;
using EmployeeMS.Shared.DTOs.JobApplications;
using EmployeeMS.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.JobApplication
{
    public class UpdateJobApplicationDto : BaseDTO ,IJobApplicationDto
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string CurrentPosition { get; set; } = string.Empty;
        public string ExperienceLevel { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;

        public int JobOfferId { get; set; }

        // Nouveau statut (accepté, rejeté, en attente…)
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;


        public List<IFormFile>? Documents { get; set; }
    }
}
