using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Employee.Requests.Commands;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(employee);
            return Unit.Value;
        }
    }
}
