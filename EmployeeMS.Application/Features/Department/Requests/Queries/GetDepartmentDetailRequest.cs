using EmployeeMS.Shared.DTOs.Department;
using MediatR;

namespace EmployeeMS.Application.Features.Department.Requests.Queries
{
    public class GetDepartmentDetailRequest : IRequest<GetDepartmentDetailsDto>
    {
        public int Id { get; set; }
    }
}
