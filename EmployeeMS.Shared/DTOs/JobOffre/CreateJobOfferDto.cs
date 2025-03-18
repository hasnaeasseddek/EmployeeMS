﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.JobOffre
{
    public class CreateJobOfferDto : IJobOfferDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string RecruitmentFileUrl { get; set; }
    }

}
