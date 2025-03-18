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
    public class UpdateJobOfferCommand :IRequest<BaseCommandResponse>
    {
        public UpdateJobOfferDto updateJobOfferDto {  get; set; }
    }
}
