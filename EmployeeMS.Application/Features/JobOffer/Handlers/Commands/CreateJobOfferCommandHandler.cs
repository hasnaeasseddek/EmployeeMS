using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobOffer.Requests.Commands;
using EmployeeMS.Application.Features.JobOffer.Validators;
using EmployeeMS.Application.Responses;
using EmployeeMS.Domain.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Handlers.Commands
{
    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, BaseCommandResponse>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateJobOfferDtoValidator();
            var validationResult = await validator.ValidateAsync(request.createJobOfferDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var joboffer = _mapper.Map<Domain.DomainEntities.JobOffer>(request.createJobOfferDto);

                await _jobOfferRepository.AddAsync(joboffer);
                response.Id = joboffer.Id;
                response.Success = true;
                response.Message = "Creation Successful";               
            }

            return response;
        }
       

    }
}
