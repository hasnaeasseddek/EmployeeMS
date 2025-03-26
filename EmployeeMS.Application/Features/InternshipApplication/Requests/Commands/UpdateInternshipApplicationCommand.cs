using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class UpdateInternshipApplicationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateInternshipApplicationDto updateInternshipApplication { get; set; }
    }

}
