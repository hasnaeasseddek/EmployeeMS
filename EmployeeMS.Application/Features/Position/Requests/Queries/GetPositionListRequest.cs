using EmployeeMS.Shared.DTOs.Position;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Requests.Queries
{
    public class GetPositionListRequest : IRequest<List<GetListAllPositionDto>>
    {
    }
}
