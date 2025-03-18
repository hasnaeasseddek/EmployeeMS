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
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, BaseCommandResponse>
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePositionCommandHandler(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdatePositionDtoValidator();
            var result = await validator.ValidateAsync(request.UpdatePositionDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var position = await _repository.GetByIdAsync(request.UpdatePositionDto.Id);
                _mapper.Map(request.UpdatePositionDto, position);
                await _repository.UpdateAsync(position);
                response.Id = position.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
