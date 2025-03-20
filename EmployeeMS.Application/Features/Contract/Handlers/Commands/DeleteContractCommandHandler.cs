using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Contract.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Handlers.Commands
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, Unit>
    {
        private readonly IContractRepository _repository;

        public DeleteContractCommandHandler(IContractRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(contract);
            return Unit.Value;
        }
    }
}
