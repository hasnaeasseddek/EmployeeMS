using EmployeeMS.Shared.DTOs.Position;
using MediatR;

namespace EmployeeMS.Application.Features.Position.Requests.Queries
{
    public class GetPositionListRequest : IRequest<List<GetListAllPositionDto>>
    {
    }
}
