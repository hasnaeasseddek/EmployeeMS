using EmployeeMS.Application.Features.LeaveRequest.Requests.Commands;
using EmployeeMS.Application.Features.LeaveRequest.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.LeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetListAllLeaveRequestDto>>> GetAll()
        {
            return await _mediator.Send(new GetLeaveRequestListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLeaveRequestDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateLeaveRequestDto dto)
        {
            var response = await _mediator.Send(new CreateLeaveRequestCommand { CreateLeaveRequestDto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdateLeaveRequestDto dto)
        {
            var response = await _mediator.Send(new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return Ok(response);
        }
    }
}
