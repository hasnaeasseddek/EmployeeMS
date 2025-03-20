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
    public class GetEmployeeTrainingDetailRequestHandler : IRequestHandler<GetEmployeeTrainingDetailRequest, GetEmployeeTrainingDetailsDto>
    {
        private readonly IEmployeeTrainingRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeTrainingDetailRequestHandler(IEmployeeTrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetEmployeeTrainingDetailsDto> Handle(GetEmployeeTrainingDetailRequest request, CancellationToken cancellationToken)
        {
            var employeeTraining = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetEmployeeTrainingDetailsDto>(employeeTraining);
        }
    }
}
