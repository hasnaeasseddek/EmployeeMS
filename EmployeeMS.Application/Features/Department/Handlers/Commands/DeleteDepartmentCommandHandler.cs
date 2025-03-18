using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Department.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Handlers.Commands
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(department);
            return Unit.Value;
        }
    }
}
