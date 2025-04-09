using EmployeeMS.Application.Features.Users.Requests.Commands;
using EmployeeMS.Application.Interfaces;
using EmployeeMS.Shared.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;

        public AuthController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            await _mediator.Send(new RegisterUserCommand(dto));
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
    }
}
