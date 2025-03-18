using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Queries
{
    public class GetJobOfferDetailRequest :IRequest<GetJobOfferDetailsDto>
    {
        public int Id { get; set; }
    }
}
