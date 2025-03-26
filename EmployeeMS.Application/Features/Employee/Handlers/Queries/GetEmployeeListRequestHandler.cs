using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Employee.Requests.Queries;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;

namespace EmployeeMS.Application.Features.Employee.Handlers.Queries
{
    public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, List<GetListAllEmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeListRequestHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllEmployeeDto>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllEmployeeDto>>(employees);
        }
    }
}
