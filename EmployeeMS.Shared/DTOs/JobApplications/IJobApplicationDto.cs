using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.JobApplications
{
    public interface IJobApplicationDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CurrentPosition { get; set; }
        public string ExperienceLevel { get; set; }
        public string Skills { get; set; }

        public int JobOfferId { get; set; }

        // Liste des fichiers joints (CV, lettres de motivation, etc.)
        public List<IFormFile>? Documents { get; set; }
    }
}
