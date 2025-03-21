using EmployeeMS.Application.Features.Employee.Requests.Commands;
using EmployeeMS.Application.Features.Employee.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetListAllEmployeeDto>> GetAllLeaveTypes()
        {
            return await _mediator.Send(new GetEmployeeListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetEmployeeDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType(CreateEmployeeDto createEmployeeDto)
        {
            var response = await _mediator.Send(new CreateEmployeeCommand { CreateEmployeeDto = createEmployeeDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateEmployeeDto updateEmployeeDto)
        {
            var response = await _mediator.Send(new UpdateEmployeeCommand { UpdateEmployeeDto = updateEmployeeDto });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(response);
        }
    }
}
