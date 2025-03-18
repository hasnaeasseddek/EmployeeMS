using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Department
{
    public class GetListAllDepartmentDto : BaseDTO
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
    }
}
