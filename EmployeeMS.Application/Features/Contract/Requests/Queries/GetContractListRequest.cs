using EmployeeMS.Shared.DTOs.Contract;
using MediatR;

namespace EmployeeMS.Application.Features.Contract.Requests.Queries
{
    public class GetContractListRequest : IRequest<List<GetListAllContractDto>>
    {
    }
}
