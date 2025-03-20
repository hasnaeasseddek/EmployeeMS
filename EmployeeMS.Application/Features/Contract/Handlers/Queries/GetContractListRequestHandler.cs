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
    public class GetContractListRequestHandler : IRequestHandler<GetContractListRequest, List<GetListAllContractDto>>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public GetContractListRequestHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllContractDto>> Handle(GetContractListRequest request, CancellationToken cancellationToken)
        {
            var contracts = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllContractDto>>(contracts);
        }
    }
}
