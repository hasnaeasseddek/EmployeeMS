using EmployeeMS.Application.Features.Training.Requests.Commands;
using EmployeeMS.Application.Features.Training.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetListAllTrainingDto>>> GetAll()
        {
            return await _mediator.Send(new GetTrainingListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTrainingDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetTrainingDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateTrainingDto dto)
        {
            var response = await _mediator.Send(new CreateTrainingCommand { CreateTrainingDto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdateTrainingDto dto)
        {
            var response = await _mediator.Send(new UpdateTrainingCommand { UpdateTrainingDto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteTrainingCommand { Id = id });
            return Ok(response);
        }
    }
}
