using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Queries
{
    public class GetInternshipApplicationDetailsRequest : IRequest<GetInternshipApplicationDetailsDto>
    {
        public int Id { get; set; }
    }
}
