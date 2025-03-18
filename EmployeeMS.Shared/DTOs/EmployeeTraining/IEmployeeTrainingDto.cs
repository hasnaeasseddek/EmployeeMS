using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.EmployeeTraining
{
    public interface IEmployeeTrainingDto
    {
        int EmployeeId { get; set; }
        int TrainingId { get; set; }
        DateTime CertificationDate { get; set; }
        string CertificateUrl { get; set; }
    }
}
