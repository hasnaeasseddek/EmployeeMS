using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Training.Requests.Commands;
using EmployeeMS.Application.Features.Training.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Handlers.Commands
{
    public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, BaseCommandResponse>
    {
        private readonly ITrainingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTrainingCommandHandler(ITrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateTrainingDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateTrainingDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var training = await _repository.GetByIdAsync(request.UpdateTrainingDto.Id);
                _mapper.Map(request.UpdateTrainingDto, training);
                await _repository.UpdateAsync(training);
                response.Id = training.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
