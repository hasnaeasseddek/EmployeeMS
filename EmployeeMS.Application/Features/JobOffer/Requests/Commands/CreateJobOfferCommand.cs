using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Commands
{
    public class CreateJobOfferCommand : IRequest<BaseCommandResponse>
    {
        public CreateJobOfferDto createJobOfferDto { get; set; }
    }
}
