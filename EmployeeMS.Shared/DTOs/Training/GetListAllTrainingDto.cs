using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Training
{
    public class GetListAllTrainingDto : BaseDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public int ParticipantCount { get; set; }
    }
}
