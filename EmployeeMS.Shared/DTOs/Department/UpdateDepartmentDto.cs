using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class UpdateDepartmentDto : IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
