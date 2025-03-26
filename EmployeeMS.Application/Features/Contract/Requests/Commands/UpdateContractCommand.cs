using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Contract;
using MediatR;

namespace EmployeeMS.Application.Features.Contract.Requests.Commands
{
    public class UpdateContractCommand : IRequest<BaseCommandResponse>
    {
        public UpdateContractDto UpdateContractDto { get; set; }
    }
}
