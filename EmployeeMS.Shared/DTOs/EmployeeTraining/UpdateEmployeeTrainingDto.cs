﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.EmployeeTraining
{
    public class UpdateEmployeeTrainingDto : IEmployeeTrainingDto
    {
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime CertificationDate { get; set; }
        public string CertificateUrl { get; set; }
    }
}
