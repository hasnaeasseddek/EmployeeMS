using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.JobOffer.Requests.Commands;
using EmployeeMS.Application.Features.JobOffer.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Handlers.Commands
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, BaseCommandResponse>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public UpdateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateJobOfferDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateJobOfferDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Joboffer = await _jobOfferRepository.GetByIdAsync(request.updateJobOfferDto.Id);
                _mapper.Map(request.updateJobOfferDto, Joboffer);
                await _jobOfferRepository.UpdateAsync(Joboffer);
                response.Id = Joboffer.Id;
                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;
            
        }
    }
}
