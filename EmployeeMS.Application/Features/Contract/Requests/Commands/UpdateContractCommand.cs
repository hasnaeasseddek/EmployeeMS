using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Requests.Commands
{
    public class UpdateContractCommand : IRequest<BaseCommandResponse>
    {
        public UpdateContractDto UpdateContractDto { get; set; }
    }
}
