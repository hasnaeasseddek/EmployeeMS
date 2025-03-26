using EmployeeMS.Shared.DTOs.Training;
using MediatR;

namespace EmployeeMS.Application.Features.Training.Requests.Queries
{
    public class GetTrainingDetailRequest : IRequest<GetTrainingDetailsDto>
    {
        public int Id { get; set; }
    }
}
