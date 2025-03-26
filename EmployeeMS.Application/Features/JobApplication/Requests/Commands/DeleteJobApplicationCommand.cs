using MediatR;

namespace EmployeeMS.Application.Features.JobApplication.Requests.Commands
{
    public class DeleteJobApplicationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
