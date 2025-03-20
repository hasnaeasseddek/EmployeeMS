using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Handlers.Commands
{
    public class DeleteEmployeeTrainingCommandHandler : IRequestHandler<DeleteEmployeeTrainingCommand, Unit>
    {
        private readonly IEmployeeTrainingRepository _repository;

        public DeleteEmployeeTrainingCommandHandler(IEmployeeTrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            var employeeTraining = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(employeeTraining);
            return Unit.Value;
        }
    }
}
