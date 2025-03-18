using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Department
{
    public interface IDepartmentDto
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
