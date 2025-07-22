using Microsoft.AspNetCore.Mvc;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;

namespace ReportManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var isValid = await _authService.ValidateUserAsync(loginDto);

            if (!isValid)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _authService.GenerateToken(loginDto.Username);

            return Ok(new { token });
        }

        //POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterDto registerDto)
        {
            var success = await _authService.RegisterUserAsync(registerDto);
            if (!success)
                return BadRequest("User already exists");

            return Ok("User created");
        } 
    }
}
