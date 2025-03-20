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
    public class UpdateJobApplicationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateJobApplicationDto updateJobApplicationDto { get; set; }
    }
}
