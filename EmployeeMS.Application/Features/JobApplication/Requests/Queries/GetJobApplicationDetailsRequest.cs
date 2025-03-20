using EmployeeMS.Shared.DTOs.JobApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Queries
{
    public class GetJobApplicationDetailsRequest :IRequest<GetJobApplicationDetailsDto>
    {
    }
}
