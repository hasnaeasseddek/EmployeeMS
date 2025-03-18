using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Department.Requests.Commands;
using EmployeeMS.Application.Features.Department.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Handlers.Commands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseCommandResponse>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDepartmentDtoValidator();
            var result = await validator.ValidateAsync(request.CreateDepartmentDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Department creation failed.";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var department = _mapper.Map<Domain.DomainEntities.Department>(request.CreateDepartmentDto);
                await _repository.AddAsync(department);
                response.Id = department.Id;
                response.Success = true;
                response.Message = "Department created successfully.";
            }

            return response;
        }
    }
}
