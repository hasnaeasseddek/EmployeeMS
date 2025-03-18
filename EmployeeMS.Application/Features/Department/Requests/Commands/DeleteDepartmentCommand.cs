using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Requests.Commands
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
