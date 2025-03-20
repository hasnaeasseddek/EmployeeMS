using EmployeeMS.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Domain.DomainEntities
{
    public class JobOffer : BaseDomainEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public JobOfferStatus Status { get; set; } = JobOfferStatus.Open;

        public string? AnnouncementFilePath { get; set; } // Stocke le chemin du fichier au lieu de IFormFile

        // Relation avec JobApplication
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }

}
