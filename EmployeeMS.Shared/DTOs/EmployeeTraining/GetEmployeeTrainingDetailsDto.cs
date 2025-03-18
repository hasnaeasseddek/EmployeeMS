using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.EmployeeTraining
{
    public class GetEmployeeTrainingDetailsDto : BaseDTO
    {
        public string EmployeeFullName { get; set; }
        public string TrainingTitle { get; set; }
        public DateTime CertificationDate { get; set; }
        public string CertificateUrl { get; set; }
    }
}
