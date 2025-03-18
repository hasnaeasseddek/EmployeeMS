using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Position.Requests.Commands;
using EmployeeMS.Application.Features.Position.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Handlers.Commands
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, BaseCommandResponse>
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePositionDtoValidator();
            var result = await validator.ValidateAsync(request.CreatePositionDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var position = _mapper.Map<EmployeeMS.Domain.DomainEntities.Position>(request.CreatePositionDto);
                await _repository.AddAsync(position);
                response.Id = position.Id;
                response.Success = true;
                response.Message = "Position Created Successfully";
            }

            return response;
        }
    }
}
