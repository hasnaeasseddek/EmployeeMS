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
    public class GetTrainingListRequestHandler : IRequestHandler<GetTrainingListRequest, List<GetListAllTrainingDto>>
    {
        private readonly ITrainingRepository _repository;
        private readonly IMapper _mapper;

        public GetTrainingListRequestHandler(ITrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllTrainingDto>> Handle(GetTrainingListRequest request, CancellationToken cancellationToken)
        {
            var trainings = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllTrainingDto>>(trainings);
        }
    }
}
