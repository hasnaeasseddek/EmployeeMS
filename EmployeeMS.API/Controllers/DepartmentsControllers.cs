using EmployeeMS.Application.Features.Department.Requests.Commands;
using EmployeeMS.Application.Features.Department.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetListAllDepartmentDto>> GetAllLeaveTypes()
        {
            return await _mediator.Send(new GetDepartmentListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetDepartmentDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType(CreateDepartmentDto createDepartmentDto)
        {
            var response = await _mediator.Send(new CreateDepartmentCommand { CreateDepartmentDto = createDepartmentDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateDepartmentDto updateDepartmentDto)
        {
            var response = await _mediator.Send(new UpdateDepartmentCommand { UpdateDepartmentDto = updateDepartmentDto });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteDepartmentCommand { Id = id });
            return Ok(response);
        }
    }
}
