using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeeListRequest : IRequest<List<GetListAllEmployeeDto>>
    {
    }
}
