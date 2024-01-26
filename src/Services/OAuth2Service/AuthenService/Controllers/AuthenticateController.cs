using Microsoft.AspNetCore.Mvc;
using Authenticate.Service.DTOs;
using AuthenService.Infrastructure;

namespace Authenticate.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthenticateController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        // GET: api/authenticate/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPasswordAsync(request);
            return StatusCode(result.StatusCode, result);
        }
    }
}
