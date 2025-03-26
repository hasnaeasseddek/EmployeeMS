using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeeDetailRequest : IRequest<GetEmployeeDetailsDto>
    {
        public int Id { get; set; }
    }
}
