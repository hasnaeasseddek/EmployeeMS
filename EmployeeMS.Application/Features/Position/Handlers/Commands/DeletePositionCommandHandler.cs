using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Position.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Handlers.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, Unit>
    {
        private readonly IPositionRepository _repository;

        public DeletePositionCommandHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(position);
            return Unit.Value;
        }
    }
}
