using EmployeeMS.Shared.DTOs.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeeListRequest : IRequest<List<GetListAllEmployeeDto>>
    {
    }
}
