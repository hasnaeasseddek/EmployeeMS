using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.JobOffre
{
    public class GetListAllJobOfferDto : BaseDTO
    {
        public string Title { get; set; } 
        public string Status { get; set; }
        public string ExpirationDate { get; set; }
        public string Description { get; set; }
        public string RecruitmentFileUrl { get; set; }
    }

}
