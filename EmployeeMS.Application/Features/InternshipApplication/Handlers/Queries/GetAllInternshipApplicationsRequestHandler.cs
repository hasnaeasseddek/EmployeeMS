using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.InternshipApplication.Requests.Queries;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Handlers.Queries
{
    public class GetAllInternshipApplicationsRequestHandler : IRequestHandler<GetAllInternshipApplicationsRequest, List<GetAllInternshipApplicationsDto>>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public GetAllInternshipApplicationsRequestHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllInternshipApplicationsDto>> Handle(GetAllInternshipApplicationsRequest request, CancellationToken cancellationToken)
        {
            var internshipApps = await _internshipApplicationRepository.GetAllAsync();
            return _mapper.Map<List<GetAllInternshipApplicationsDto>>(internshipApps);
        }
    }
}
