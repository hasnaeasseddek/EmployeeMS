using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class CreateJobApplicationCommand :IRequest<BaseCommandResponse>
    {
        public CreateJobApplicationDto CreateJobApplicationDto { get; set; }
    }
}
