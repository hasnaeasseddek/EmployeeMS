using EmployeeMS.Shared.DTOs.JobApplications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.JobApplication
{
    public class CreateJobApplicationDto : IJobApplicationDto
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

        // Liste des fichiers joints (CV, lettres de motivation, etc.)
        public List<IFormFile>? Documents { get; set; }
    }
}
