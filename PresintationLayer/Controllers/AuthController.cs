using ApplicationLayer.DTOs.AuthDTOs;
using ApplicationLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresintationLayer.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authservice )
        {
            _authservice = authservice;
        }

        // Route -> Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            var registerResult = await _authservice.RegisterAsync(registerDto);

            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var loginResult = await _authservice.LoginAsync(loginDto);

            if (loginResult.IsSucceed)
                return Ok(loginResult);

            return Unauthorized(loginResult);

        }
    }

}
