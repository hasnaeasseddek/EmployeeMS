using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class DeleteInternshipApplicationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
