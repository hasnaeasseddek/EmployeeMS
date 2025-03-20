using EmployeeMS.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Contracts.Persistence
{
    public interface IAttendanceRepository: IGenericRepository<Attendance>
    {
    }
}
