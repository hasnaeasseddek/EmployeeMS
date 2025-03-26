using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Queries
{
    public class GetJobOfferDetailRequest : IRequest<GetJobOfferDetailsDto>
    {
        public int Id { get; set; }
    }
}
