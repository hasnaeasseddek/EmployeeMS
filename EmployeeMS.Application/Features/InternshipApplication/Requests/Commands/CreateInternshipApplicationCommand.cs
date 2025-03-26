using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class CreateInternshipApplicationCommand : IRequest<BaseCommandResponse>
    {
        public CreateInternshipApplicationDto createInternshipApplication { get; set; }
    }
}
