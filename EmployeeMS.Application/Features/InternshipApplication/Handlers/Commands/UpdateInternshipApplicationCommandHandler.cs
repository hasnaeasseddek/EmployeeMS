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
    public class UpdateInternshipApplicationCommandHandler : IRequestHandler<UpdateInternshipApplicationCommand, BaseCommandResponse>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public UpdateInternshipApplicationCommandHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateInternshipApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateInternshipApplicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateInternshipApplication);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var internshipApp = await _internshipApplicationRepository.GetByIdAsync(request.updateInternshipApplication.Id);
                _mapper.Map(request.updateInternshipApplication, internshipApp);
                await _internshipApplicationRepository.UpdateAsync(internshipApp);
                response.Id = internshipApp.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}
