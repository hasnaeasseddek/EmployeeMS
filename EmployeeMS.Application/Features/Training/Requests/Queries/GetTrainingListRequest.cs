using EmployeeMS.Shared.DTOs.Training;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Requests.Queries
{
    public class GetTrainingListRequest : IRequest<List<GetListAllTrainingDto>>
    {
    }
}
