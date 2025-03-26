using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Queries
{
    public class GetAllInternshipApplicationsRequest : IRequest<List<GetAllInternshipApplicationsDto>>
    {
    }
}
