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
    public class GetPositionDetailRequestHandler : IRequestHandler<GetPositionDetailRequest, GetPositionDetailsDto>
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public GetPositionDetailRequestHandler(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPositionDetailsDto> Handle(GetPositionDetailRequest request, CancellationToken cancellationToken)
        {
            var position = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetPositionDetailsDto>(position);
        }
    }
}
