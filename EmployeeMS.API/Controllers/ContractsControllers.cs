using EmployeeMS.Application.Features.Contract.Requests.Commands;
using EmployeeMS.Application.Features.Contract.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractsControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetListAllContractDto>> GetAllLeaveTypes()
        {
            return await _mediator.Send(new GetContractListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetContractDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetContractDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType(CreateContractDto createContractDto)
        {
            var response = await _mediator.Send(new CreateContractCommand { CreateContractDto = createContractDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateContractDto updateContractDto)
        {
            var response = await _mediator.Send(new UpdateContractCommand { UpdateContractDto = updateContractDto });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteContractCommand { Id = id });
            return Ok(response);
        }
    }
}
