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
    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, BaseCommandResponse>
    {
        private readonly ITrainingRepository _repository;
        private readonly IMapper _mapper;

        public CreateTrainingCommandHandler(ITrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainingDtoValidator();
            var result = await validator.ValidateAsync(request.CreateTrainingDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var training = _mapper.Map<EmployeeMS.Domain.DomainEntities.Training>(request.CreateTrainingDto);
                await _repository.AddAsync(training);
                response.Id = training.Id;
                response.Success = true;
                response.Message = "Training Created Successfully";
            }

            return response;
        }
    }
}
