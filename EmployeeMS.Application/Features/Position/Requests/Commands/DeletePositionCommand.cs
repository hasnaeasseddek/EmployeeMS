using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Requests.Commands
{
    public class DeletePositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
