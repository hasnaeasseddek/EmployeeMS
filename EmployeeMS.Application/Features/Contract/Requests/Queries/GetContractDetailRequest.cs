using EmployeeMS.Shared.DTOs.Contract;
using MediatR;

namespace EmployeeMS.Application.Features.Contract.Requests.Queries
{
    public class GetContractDetailRequest : IRequest<GetContractDetailsDto>
    {
        public int Id { get; set; }
    }
}
