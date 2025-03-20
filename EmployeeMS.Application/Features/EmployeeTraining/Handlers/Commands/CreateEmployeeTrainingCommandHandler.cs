using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands;
using EmployeeMS.Application.Features.EmployeeTraining.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Handlers.Commands
{
    public class CreateEmployeeTrainingCommandHandler : IRequestHandler<CreateEmployeeTrainingCommand, BaseCommandResponse>
    {
        private readonly IEmployeeTrainingRepository _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeTrainingCommandHandler(IEmployeeTrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmployeeTrainingDtoValidator();
            var result = await validator.ValidateAsync(request.CreateEmployeeTrainingDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var employeeTraining = _mapper.Map<EmployeeMS.Domain.DomainEntities.EmployeeTraining>(request.CreateEmployeeTrainingDto);
                await _repository.AddAsync(employeeTraining);
                response.Id = employeeTraining.EmployeeId;
                response.Success = true;
                response.Message = "Employee Training Created Successfully";
            }

            return response;
        }
    }
}
