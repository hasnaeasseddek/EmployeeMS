using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobApplication.Requests.Commands;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Handlers.Commands
{
    public class DeleteJobApplicationCommandHandler : IRequestHandler<DeleteJobApplicationCommand>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public DeleteJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }
        public Task<Unit> Handle(DeleteJobApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
