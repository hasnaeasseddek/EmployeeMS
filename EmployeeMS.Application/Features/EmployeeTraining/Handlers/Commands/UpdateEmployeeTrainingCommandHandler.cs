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
    public class UpdateEmployeeTrainingCommandHandler : IRequestHandler<UpdateEmployeeTrainingCommand, BaseCommandResponse>
    {
        private readonly IEmployeeTrainingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEmployeeTrainingCommandHandler(IEmployeeTrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateEmployeeTrainingDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateEmployeeTrainingDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var employeeTraining = await _repository.GetByIdAsync(request.UpdateEmployeeTrainingDto.Id);
                _mapper.Map(request.UpdateEmployeeTrainingDto, employeeTraining);
                await _repository.UpdateAsync(employeeTraining);
                response.Id = employeeTraining.EmployeeId;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
