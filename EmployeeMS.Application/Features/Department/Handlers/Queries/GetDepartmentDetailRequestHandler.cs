using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Department.Requests.Queries;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;

namespace EmployeeMS.Application.Features.Department.Handlers.Queries
{
    public class GetDepartmentDetailRequestHandler : IRequestHandler<GetDepartmentDetailRequest, GetDepartmentDetailsDto>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public GetDepartmentDetailRequestHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetDepartmentDetailsDto> Handle(GetDepartmentDetailRequest request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetDepartmentDetailsDto>(department);
        }
    }
}
