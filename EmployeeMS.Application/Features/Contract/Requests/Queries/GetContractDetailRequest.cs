using EmployeeMS.Shared.DTOs.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Contract.Requests.Queries
{
    public class GetContractDetailRequest : IRequest<GetContractDetailsDto>
    {
        public int Id { get; set; }
    }
}
