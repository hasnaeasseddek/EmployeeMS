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
    public class GetJobOfferListRequestHandler : IRequestHandler<GetJobOfferListRequest, List<GetListAllJobOfferDto>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public GetJobOfferListRequestHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListAllJobOfferDto>> Handle(GetJobOfferListRequest request, CancellationToken cancellationToken)
        {
            var JobOffers = await _jobOfferRepository.GetAllAsync();
            return _mapper.Map<List<GetListAllJobOfferDto>>(JobOffers);
        }
    }
}
