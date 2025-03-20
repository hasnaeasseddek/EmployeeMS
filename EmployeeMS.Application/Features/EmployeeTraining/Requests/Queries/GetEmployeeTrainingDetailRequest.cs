using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Queries
{
    public class GetEmployeeTrainingDetailRequest : IRequest<GetEmployeeTrainingDetailsDto>
    {
        public int Id { get; set; }
    }
}
