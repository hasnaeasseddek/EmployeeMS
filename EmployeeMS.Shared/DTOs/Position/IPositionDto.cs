using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Position
{
    public interface IPositionDto
    {
        string Title { get; set; }
        string Description { get; set; }
        decimal BaseSalary { get; set; }
    }
}
