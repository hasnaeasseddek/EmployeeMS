using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class UpdateInternshipApplicationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateInternshipApplicationDto updateInternshipApplication { get; set; }
    }
   
}
