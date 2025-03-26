using EmployeeMS.Shared.DTOs.Position;
using MediatR;

namespace EmployeeMS.Application.Features.Position.Requests.Queries
{
    public class GetPositionDetailRequest : IRequest<GetPositionDetailsDto>
    {
        public int Id { get; set; }
    }
}
