using MediatR;

namespace EmployeeMS.Application.Features.JobOffer.Requests.Commands
{
    public class DeleteJobOfferCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
