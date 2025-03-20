using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobApplication.Requests.Commands;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Handlers.Commands
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, BaseCommandResponse>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }
        public Task<BaseCommandResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
