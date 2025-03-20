using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Requests.Commands
{
    public class DeleteContractCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
