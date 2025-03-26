using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Commands
{
    public class UpdateJobOfferCommand : IRequest<BaseCommandResponse>
    {
        public UpdateJobOfferDto UpdateJobOfferDto { get; set; }
    }
}
