using EmployeeMS.Application.Features.InternshipApplication.Requests.Commands;
using EmployeeMS.Application.Features.InternshipApplication.Requests.Queries;
using EmployeeMS.Application.Features.JobOffer.Requests.Commands;
using EmployeeMS.Application.Features.JobOffer.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipApplController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InternshipApplController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllInternshipApplicationsDto>> GetAlls()
        {
            return await _mediator.Send(new GetAllInternshipApplicationsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetInternshipApplicationDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetInternshipApplicationDetailsRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType([FromForm]CreateInternshipApplicationDto createInternshipApplication)
        {
            var response = await _mediator.Send(new CreateInternshipApplicationCommand { createInternshipApplication = createInternshipApplication });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateInternshipApplicationDto updateInternshipApplication)
        {
            var response = await _mediator.Send(new UpdateInternshipApplicationCommand { updateInternshipApplication = updateInternshipApplication });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteInternshipApplicationCommand { Id = id });
            return Ok(response);
        }
    }
}
