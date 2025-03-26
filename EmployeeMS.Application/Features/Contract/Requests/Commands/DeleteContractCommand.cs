using MediatR;

namespace EmployeeMS.Application.Features.Contract.Requests.Commands
{
    public class DeleteContractCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
