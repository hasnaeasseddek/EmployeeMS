using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.InternshipApplication.Requests.Commands;
using EmployeeMS.Application.Features.InternshipApplication.Validators;
using EmployeeMS.Application.Features.JobOffer.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Handlers.Commands
{
    public class CreateInternshipApplicationCommandHandler : IRequestHandler<CreateInternshipApplicationCommand, BaseCommandResponse>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public CreateInternshipApplicationCommandHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateInternshipApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInternshipApplicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.createInternshipApplication);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var internshipApp = _mapper.Map<Domain.DomainEntities.InternshipApplication>(request.createInternshipApplication);

                await _internshipApplicationRepository.AddAsync(internshipApp);
                response.Id = internshipApp.Id;
                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;

        }
    }
}
