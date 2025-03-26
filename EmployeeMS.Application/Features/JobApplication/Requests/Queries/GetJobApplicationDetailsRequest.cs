using EmployeeMS.Shared.DTOs.JobApplications;
using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Queries
{
    public class GetJobApplicationDetailsRequest : IRequest<GetJobApplicationDetailsDto>
    {
        public int Id { get; set; }
    }
}
