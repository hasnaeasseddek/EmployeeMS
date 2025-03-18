using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobOffer.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Handlers.Commands
{
    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand, Unit>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public DeleteJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteJobOfferCommand request, CancellationToken cancellationToken)
        {
            var joboffer = await _jobOfferRepository.GetByIdAsync(request.Id);
            await _jobOfferRepository.DeleteAsync(joboffer);
            return Unit.Value;
        }
    }
}
