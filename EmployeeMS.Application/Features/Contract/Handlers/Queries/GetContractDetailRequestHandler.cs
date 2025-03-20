using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Contract.Requests.Queries;
using EmployeeMS.Shared.DTOs.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Handlers.Queries
{
    public class GetContractDetailRequestHandler : IRequestHandler<GetContractDetailRequest, GetContractDetailsDto>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public GetContractDetailRequestHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetContractDetailsDto> Handle(GetContractDetailRequest request, CancellationToken cancellationToken)
        {
            var contract = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetContractDetailsDto>(contract);
        }
    }
}
