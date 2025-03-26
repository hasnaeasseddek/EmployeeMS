using EmployeeMS.Shared.DTOs.JobApplication;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Queries
{
    public class GetAllJobApplicationsRequest : IRequest<List<GetAllJobApplicationsDto>>
    {
    }
}
