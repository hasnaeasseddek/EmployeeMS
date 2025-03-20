using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class DeleteInternshipApplicationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
