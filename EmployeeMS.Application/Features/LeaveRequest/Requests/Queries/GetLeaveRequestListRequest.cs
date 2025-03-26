using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;

namespace EmployeeMS.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<GetListAllLeaveRequestDto>>
    {
    }
}
