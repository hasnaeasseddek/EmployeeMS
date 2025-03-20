using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobApplication.Requests.Queries;
using EmployeeMS.Shared.DTOs.JobApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Handlers.Queries
{
    public class GetJobApplicationDetailsRequestHandler : IRequestHandler<GetJobApplicationDetailsRequest, GetJobApplicationDetailsDto>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public GetJobApplicationDetailsRequestHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }
        public Task<GetJobApplicationDetailsDto> Handle(GetJobApplicationDetailsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
