using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Requests.Commands
{
    public class DeleteTrainingCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
