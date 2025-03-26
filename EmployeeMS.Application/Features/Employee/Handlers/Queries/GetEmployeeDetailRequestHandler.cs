using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Employee.Requests.Queries;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Handlers.Queries
{
    public class GetEmployeeDetailRequestHandler : IRequestHandler<GetEmployeeDetailRequest, GetEmployeeDetailsDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailRequestHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetEmployeeDetailsDto> Handle(GetEmployeeDetailRequest request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetEmployeeDetailsDto>(employee);
        }
    }
}
