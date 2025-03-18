using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Employee.Requests.Commands;
using EmployeeMS.Application.Features.Employee.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Employee.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;


        public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateEmployeeDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateEmployeeDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var employee = await _repository.GetByIdAsync(request.UpdateEmployeeDto.Id);
                _mapper.Map(request.UpdateEmployeeDto, employee);
                await _repository.UpdateAsync(employee);
                response.Id = employee.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
