using EmployeeMS.Shared.DTOs.Training;
using MediatR;

namespace EmployeeMS.Application.Features.Training.Requests.Queries
{
    public class GetTrainingListRequest : IRequest<List<GetListAllTrainingDto>>
    {
    }
}
