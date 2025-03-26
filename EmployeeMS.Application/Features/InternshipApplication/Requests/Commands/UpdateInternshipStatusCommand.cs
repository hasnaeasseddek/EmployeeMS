using EmployeeMS.Application.Responses;
using MediatR;

namespace EmployeeMS.Application.Features.InternshipApplication.Requests.Commands
{
    public class UpdateInternshipStatusCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public string status { get; set; }
    }
}
