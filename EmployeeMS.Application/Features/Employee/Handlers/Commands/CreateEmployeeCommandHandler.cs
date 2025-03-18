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
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmployeeDtoValidator();
            var result = await validator.ValidateAsync(request.CreateEmployeeDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var employee = _mapper.Map<Domain.DomainEntities.Employee >(request.CreateEmployeeDto);
                await _repository.AddAsync(employee);
                response.Id = employee.Id;
                response.Success = true;
                response.Message = "Employee Created Successfully";
            }

            return response;
        }
    }
}
