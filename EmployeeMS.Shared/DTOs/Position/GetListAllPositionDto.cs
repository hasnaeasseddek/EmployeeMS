using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Position
{
    public class GetListAllPositionDto : BaseDTO
    {
        public string Title { get; set; }
        public decimal BaseSalary { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
