using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobOffer.Requests.Queries;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Handlers.Queries
{
    public class GetJobOfferDetailRequestHandler : IRequestHandler<GetJobOfferDetailRequest, GetJobOfferDetailsDto>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public GetJobOfferDetailRequestHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }
        public async Task<GetJobOfferDetailsDto> Handle(GetJobOfferDetailRequest request, CancellationToken cancellationToken)
        {
            var JobOffer = await _jobOfferRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetJobOfferDetailsDto>(JobOffer);
        }
    }
}
