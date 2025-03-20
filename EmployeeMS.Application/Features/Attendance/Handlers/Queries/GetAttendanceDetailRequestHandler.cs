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
    public class GetAttendanceDetailRequestHandler : IRequestHandler<GetAttendanceDetailRequest, GetAttendanceDetailsDto>
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;

        public GetAttendanceDetailRequestHandler(IAttendanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAttendanceDetailsDto> Handle(GetAttendanceDetailRequest request, CancellationToken cancellationToken)
        {
            var attendance = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetAttendanceDetailsDto>(attendance);
        }
    }
}
