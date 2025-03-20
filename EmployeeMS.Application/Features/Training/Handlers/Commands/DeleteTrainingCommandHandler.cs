using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Training.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Handlers.Commands
{
    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, Unit>
    {
        private readonly ITrainingRepository _repository;

        public DeleteTrainingCommandHandler(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            var training = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(training);
            return Unit.Value;
        }
    }
}
