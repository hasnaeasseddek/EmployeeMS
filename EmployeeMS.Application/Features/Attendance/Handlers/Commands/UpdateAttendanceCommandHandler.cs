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
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, BaseCommandResponse>
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAttendanceCommandHandler(IAttendanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateAttendanceDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateAttendanceDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var attendance = await _repository.GetByIdAsync(request.UpdateAttendanceDto.Id);
                _mapper.Map(request.UpdateAttendanceDto, attendance);
                await _repository.UpdateAsync(attendance);
                response.Id = attendance.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
