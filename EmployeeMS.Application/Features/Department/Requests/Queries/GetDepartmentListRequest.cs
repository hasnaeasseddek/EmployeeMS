using EmployeeMS.Shared.DTOs.Department;
using MediatR;

namespace EmployeeMS.Application.Features.Department.Requests.Queries
{
    public class GetDepartmentListRequest : IRequest<List<GetListAllDepartmentDto>>
    {
    }
}
