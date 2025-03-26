using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Queries
{
    public class GetJobOfferListRequest : IRequest<List<GetListAllJobOfferDto>>
    {
    }
}
