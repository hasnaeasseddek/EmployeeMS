using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Contract
{
    public class GetListAllContractDto : BaseDTO
    {
        public string EmployeeFullName { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public string ContractType { get; set; }
    }
}
