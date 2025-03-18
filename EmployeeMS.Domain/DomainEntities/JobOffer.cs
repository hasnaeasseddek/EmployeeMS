using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Domain.DomainEntities
{
    public class JobOffer : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; } // CDI, CDD...
        public DateTime? ExpirationDate { get; set; }
        public string? Status { get; set; } 
        public string? RecruitmentFileUrl { get; set; } 
    }
}
