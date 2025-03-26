using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;

namespace EmployeeMS.Application.Features.EmployeeTraining.Requests.Queries
{
    public class GetEmployeeTrainingListRequest : IRequest<List<GetListAllEmployeeTrainingDto>>
    {
    }
}
