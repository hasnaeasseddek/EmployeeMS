using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class ChangeJobAppStatusCommand :IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public ApplicationStatus status { get; set; }

    }
}
