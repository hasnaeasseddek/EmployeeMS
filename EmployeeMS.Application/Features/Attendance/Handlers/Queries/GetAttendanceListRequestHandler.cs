using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.Attendance.Requests.Queries;
using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Handlers.Queries
{
    public class GetAttendanceListRequestHandler : IRequestHandler<GetAttendanceListRequest, List<GetListAllAttendanceDto>>
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;

        public GetAttendanceListRequestHandler(IAttendanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllAttendanceDto>> Handle(GetAttendanceListRequest request, CancellationToken cancellationToken)
        {
            var attendances = await _repository.GetAllAsync();
            return _mapper.Map<List<GetListAllAttendanceDto>>(attendances);
        }
    }
}
