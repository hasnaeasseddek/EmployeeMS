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
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseCommandResponse>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateDepartmentDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateDepartmentDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var department = await _repository.GetByIdAsync(request.UpdateDepartmentDto.Id);
                _mapper.Map(request.UpdateDepartmentDto, department);
                await _repository.UpdateAsync(department);
                response.Id = department.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
