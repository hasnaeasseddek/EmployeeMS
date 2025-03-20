using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Contract.Requests.Commands;
using EmployeeMS.Application.Features.Contract.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Handlers.Commands
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, BaseCommandResponse>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public UpdateContractCommandHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateContractDtoValidator();
            var result = await validator.ValidateAsync(request.UpdateContractDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var contract = await _repository.GetByIdAsync(request.UpdateContractDto.Id);
                _mapper.Map(request.UpdateContractDto, contract);
                await _repository.UpdateAsync(contract);
                response.Id = contract.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
