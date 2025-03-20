using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Training;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Requests.Commands
{
    public class UpdateTrainingCommand : IRequest<BaseCommandResponse>
    {
        public UpdateTrainingDto UpdateTrainingDto { get; set; }
    }
}
