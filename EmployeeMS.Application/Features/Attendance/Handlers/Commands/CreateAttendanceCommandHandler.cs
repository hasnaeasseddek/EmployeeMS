using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Attendance.Requests.Commands;
using EmployeeMS.Application.Features.Attendance.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Handlers.Commands
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, BaseCommandResponse>
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;

        public CreateAttendanceCommandHandler(IAttendanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAttendanceDtoValidator();
            var result = await validator.ValidateAsync(request.CreateAttendanceDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var attendance = _mapper.Map<EmployeeMS.Domain.DomainEntities.Attendance>(request.CreateAttendanceDto);
                await _repository.AddAsync(attendance);
                response.Id = attendance.Id;
                response.Success = true;
                response.Message = "Attendance Created Successfully";
            }

            return response;
        }
    }
}
