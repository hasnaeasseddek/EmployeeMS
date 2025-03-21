using EmployeeMS.Application.Features.JobOffer.Requests.Commands;
using EmployeeMS.Application.Features.JobOffer.Requests.Queries;
using EmployeeMS.Application.Responses;
using EmployeeMS.Shared.DTOs.JobOffre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobOffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetListAllJobOfferDto>> GetAllLeaveTypes()
        {
            return await _mediator.Send(new GetJobOfferListRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobOfferDetailsDto>> GetById(int id)
        {
            return await _mediator.Send(new GetJobOfferDetailRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddLeaveType(CreateJobOfferDto createJobOfferDto)
        {
            var response = await _mediator.Send(new CreateJobOfferCommand { CreateJobOfferDto  = createJobOfferDto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(UpdateJobOfferDto updateJobOfferDto)
        {
            var response = await _mediator.Send(new UpdateJobOfferCommand { UpdateJobOfferDto = updateJobOfferDto });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var response = await _mediator.Send(new DeleteJobOfferCommand { Id = id });
            return Ok(response);
        }
    }
}
