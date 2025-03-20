using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Training.Requests.Queries;
using EmployeeMS.Shared.DTOs.Training;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Handlers.Queries
{
    public class GetTrainingDetailRequestHandler : IRequestHandler<GetTrainingDetailRequest, GetTrainingDetailsDto>
    {
        private readonly ITrainingRepository _repository;
        private readonly IMapper _mapper;

        public GetTrainingDetailRequestHandler(ITrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTrainingDetailsDto> Handle(GetTrainingDetailRequest request, CancellationToken cancellationToken)
        {
            var training = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetTrainingDetailsDto>(training);
        }
    }
}
