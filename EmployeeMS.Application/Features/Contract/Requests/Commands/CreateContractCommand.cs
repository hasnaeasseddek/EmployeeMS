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
    public class CreateContractCommand : IRequest<BaseCommandResponse>
    {
        public CreateContractDto CreateContractDto { get; set; }
    }
}
