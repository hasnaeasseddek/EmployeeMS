using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;

namespace EmployeeMS.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<GetLeaveRequestDetailsDto>
    {
        public int Id { get; set; }
    }
}
