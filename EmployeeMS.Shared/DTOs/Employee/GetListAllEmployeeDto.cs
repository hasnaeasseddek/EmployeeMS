using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Employee
{
    public class GetListAllEmployeeDto: BaseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string PositionTitle { get; set; }
        public DateTime DateHired { get; set; }
    }
}
