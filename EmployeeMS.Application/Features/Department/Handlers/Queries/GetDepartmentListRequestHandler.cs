using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Department.Requests.Queries;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Handlers.Queries
{
    public class GetDepartmentListRequestHandler : IRequestHandler<GetDepartmentListRequest, List<GetListAllDepartmentDto>>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public GetDepartmentListRequestHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllDepartmentDto>> Handle(GetDepartmentListRequest request, CancellationToken cancellationToken)
        {
            var departments = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllDepartmentDto>>(departments);
        }
    }
}
