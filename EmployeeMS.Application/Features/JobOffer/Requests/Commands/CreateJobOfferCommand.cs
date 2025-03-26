using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Commands
{
    public class CreateJobOfferCommand : IRequest<BaseCommandResponse>
    {
        public CreateJobOfferDto CreateJobOfferDto { get; set; }
    }
}
