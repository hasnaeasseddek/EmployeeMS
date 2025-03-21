using EmployeeMS.Application.Features.Attendance.Requests.Commands;
using EmployeeMS.Application.Features.Attendance.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Attendance;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendancesControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetListAllAttendanceDto>> GetAllLeaveTypes()
        {
            return await _mediator.Send(new GetAttendanceListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAttendanceDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetAttendanceDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType(CreateAttendanceDto createAttendanceDto)
        {
            var response = await _mediator.Send(new CreateAttendanceCommand { CreateAttendanceDto = createAttendanceDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateAttendanceDto updateAttendanceDto)
        {
            var response = await _mediator.Send(new UpdateAttendanceCommand { UpdateAttendanceDto = updateAttendanceDto });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteAttendanceCommand { Id = id });
            return Ok(response);
        }
    }
}
