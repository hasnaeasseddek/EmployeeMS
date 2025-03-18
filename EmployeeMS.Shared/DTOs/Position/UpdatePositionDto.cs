using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Position
{
    public class UpdatePositionDto :BaseDTO, IPositionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal BaseSalary { get; set; }
    }
}
