using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.EmployeeTraining.Requests.Queries;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Handlers.Queries
{
    public class GetEmployeeTrainingListRequestHandler : IRequestHandler<GetEmployeeTrainingListRequest, List<GetListAllEmployeeTrainingDto>>
    {
        private readonly IEmployeeTrainingRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeTrainingListRequestHandler(IEmployeeTrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllEmployeeTrainingDto>> Handle(GetEmployeeTrainingListRequest request, CancellationToken cancellationToken)
        {
            var trainings = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllEmployeeTrainingDto>>(trainings);
        }
    }
}
