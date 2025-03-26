using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobApplication.Requests.Commands;
using EmployeeMS.Application.Responses;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Handlers.Commands
{
    public class UpdateJobApplicationCommandHandler : IRequestHandler<UpdateJobApplicationCommand, BaseCommandResponse>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public UpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }

        public Task<BaseCommandResponse> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
