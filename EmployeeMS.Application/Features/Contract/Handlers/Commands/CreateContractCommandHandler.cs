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
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, BaseCommandResponse>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public CreateContractCommandHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateContractDtoValidator();
            var result = await validator.ValidateAsync(request.CreateContractDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var contract = _mapper.Map<EmployeeMS.Domain.DomainEntities.Contract>(request.CreateContractDto);
                await _repository.AddAsync(contract);
                response.Id = contract.Id;
                response.Success = true;
                response.Message = "Contract Created Successfully";
            }

            return response;
        }
    }
}
