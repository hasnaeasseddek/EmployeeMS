using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Queries
{
    public class GetAllInternshipApplicationsRequest :IRequest<List<GetAllInternshipApplicationsDto>>
    {
    }
}
