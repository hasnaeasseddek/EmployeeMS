using EmployeeMS.Application.Features.EmployeeTraining.Requests.Commands;
using EmployeeMS.Application.Features.EmployeeTraining.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTrainingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeTrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetListAllEmployeeTrainingDto>>> GetAll()
        {
            return await _mediator.Send(new GetEmployeeTrainingListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeTrainingDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetEmployeeTrainingDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateEmployeeTrainingDto dto)
        {
            var response = await _mediator.Send(new CreateEmployeeTrainingCommand { CreateEmployeeTrainingDto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdateEmployeeTrainingDto dto)
        {
            var response = await _mediator.Send(new UpdateEmployeeTrainingCommand { UpdateEmployeeTrainingDto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteEmployeeTrainingCommand { Id = id });
            return Ok(response);
        }
    }
}
