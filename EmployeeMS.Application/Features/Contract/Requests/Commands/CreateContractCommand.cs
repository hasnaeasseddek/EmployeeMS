using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Contract;
using MediatR;

namespace EmployeeMS.Application.Features.Contract.Requests.Commands
{
    public class CreateContractCommand : IRequest<BaseCommandResponse>
    {
        public CreateContractDto CreateContractDto { get; set; }
    }
}
