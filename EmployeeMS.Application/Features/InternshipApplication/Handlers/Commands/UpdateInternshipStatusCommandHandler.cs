using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.InternshipApplication.Requests.Commands;
using EmployeeMS.Application.Responses;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Handlers.Commands
{
    public class UpdateInternshipStatusCommandHandler : IRequestHandler<UpdateInternshipStatusCommand, BaseCommandResponse>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public UpdateInternshipStatusCommandHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateInternshipStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var internshipApp = await _internshipApplicationRepository.GetByIdAsync(request.Id);

            if (internshipApp == null)
            {
                response.Success = false;
                response.Message = "Update Failed";
            }
            else
            {
                await _internshipApplicationRepository.UpdateStatus(request.status, internshipApp);
                response.Id = internshipApp.Id;
                response.Success = true;
                response.Message = "Update Successful";
            }

            return response;
        }
    }
}