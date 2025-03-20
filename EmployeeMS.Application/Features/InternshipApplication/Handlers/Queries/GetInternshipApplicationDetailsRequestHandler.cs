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
    public class GetInternshipApplicationDetailsRequestHandler : IRequestHandler<GetInternshipApplicationDetailsRequest, GetInternshipApplicationDetailsDto>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public GetInternshipApplicationDetailsRequestHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }
        public async Task<GetInternshipApplicationDetailsDto> Handle(GetInternshipApplicationDetailsRequest request, CancellationToken cancellationToken)
        {
            var internshipapplication = await _internshipApplicationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetInternshipApplicationDetailsDto>(internshipapplication);
        }
    }
}
