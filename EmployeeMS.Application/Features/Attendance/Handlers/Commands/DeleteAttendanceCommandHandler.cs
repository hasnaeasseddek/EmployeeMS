using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Attendance.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Handlers.Commands
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, Unit>
    {
        private readonly IAttendanceRepository _repository;

        public DeleteAttendanceCommandHandler(IAttendanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendance = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(attendance);
            return Unit.Value;
        }
    }
}
