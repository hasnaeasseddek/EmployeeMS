using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.InternshipApplication.Validators;
using EmployeeMS.Application.Features.JobApplication.Requests.Commands;
using EmployeeMS.Application.Features.JobApplication.Validators;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Handlers.Commands
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, BaseCommandResponse>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateJobApplicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateJobApplicationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var jobapplication = _mapper.Map<Domain.DomainEntities.JobApplication>(request.CreateJobApplicationDto);

                await _jobApplicationRepository.AddAsync(jobapplication);
                response.Id = jobapplication.Id;
                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;
        }
    }
}
