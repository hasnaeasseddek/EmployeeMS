using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Queries
{
    public class GetEmployeeTrainingDetailRequest : IRequest<GetEmployeeTrainingDetailsDto>
    {
        public int Id { get; set; }
    }
}
