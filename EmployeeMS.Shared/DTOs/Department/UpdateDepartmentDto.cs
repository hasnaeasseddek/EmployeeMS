using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class UpdateDepartmentDto :BaseDTO, IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
