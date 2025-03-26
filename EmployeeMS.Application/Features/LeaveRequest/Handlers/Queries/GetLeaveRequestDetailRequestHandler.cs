using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.LeaveRequest.Requests.Queries;
using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;

namespace EmployeeMS.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, GetLeaveRequestDetailsDto>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetLeaveRequestDetailsDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetLeaveRequestDetailsDto>(leaveRequest);
        }
    }
}
