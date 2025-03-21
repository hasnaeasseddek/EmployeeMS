using EmployeeMS.Application.Features.Position.Requests.Commands;
using EmployeeMS.Application.Features.Position.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Position;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetListAllPositionDto>>> GetAll()
        {
            return await _mediator.Send(new GetPositionListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPositionDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetPositionDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreatePositionDto dto)
        {
            var response = await _mediator.Send(new CreatePositionCommand { CreatePositionDto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdatePositionDto dto)
        {
            var response = await _mediator.Send(new UpdatePositionCommand { UpdatePositionDto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeletePositionCommand { Id = id });
            return Ok(response);
        }
    }
}
