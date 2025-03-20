using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class DeleteJobApplicationCommand :IRequest
    {
        public int Id{ get; set; }
    }
}
