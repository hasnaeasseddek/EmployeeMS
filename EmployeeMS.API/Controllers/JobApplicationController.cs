using EmployeeMS.Application.Features.JobApplication.Requests.Commands;
using EmployeeMS.Application.Features.JobApplication.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobApplication;
using EmployeeMS.Shared.DTOs.JobApplications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllJobApplicationsDto>> GetAll()
        {
            return await _mediator.Send(new GetAllJobApplicationsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobApplicationDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetJobApplicationDetailsRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Add(CreateJobApplicationDto createJobApplicationDto)
        {
            var response = await _mediator.Send(new CreateJobApplicationCommand { CreateJobApplicationDto = createJobApplicationDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdateJobApplicationDto updateJobApplication)
        {
            var response = await _mediator.Send(new UpdateJobApplicationCommand { UpdateJobApplicationDto = updateJobApplication });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteJobApplicationCommand { Id = id });
            return Ok(response);
        }
    }
}
