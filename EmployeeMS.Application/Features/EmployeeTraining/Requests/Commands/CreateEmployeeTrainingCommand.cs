using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands
{
    public class CreateEmployeeTrainingCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmployeeTrainingDto CreateEmployeeTrainingDto { get; set; }
    }
}
