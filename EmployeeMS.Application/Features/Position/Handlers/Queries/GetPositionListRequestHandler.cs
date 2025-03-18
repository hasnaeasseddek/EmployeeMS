using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Position.Requests.Queries;
using EmployeeMS.Shared.DTOs.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Handlers.Queries
{
    public class GetPositionListRequestHandler : IRequestHandler<GetPositionListRequest, List<GetListAllPositionDto>>
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public GetPositionListRequestHandler(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllPositionDto>> Handle(GetPositionListRequest request, CancellationToken cancellationToken)
        {
            var positions = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllPositionDto>>(positions);
        }
    }
}
