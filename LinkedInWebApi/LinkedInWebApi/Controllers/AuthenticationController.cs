using LinkedInWebApi.Application.Dto;
using LinkedInWebApi.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInWebApi.Controllers
{
    /// <summary>
    /// Controller for authentication
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationHandler _authenticationHandler;

        public AuthenticationController(IAuthenticationHandler authenticationHandler)
        {
            _authenticationHandler = authenticationHandler;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();

        }

        /// <summary>
        /// Register
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                var registerUserResult = await _authenticationHandler.RegisterUserHandler(registerDto);
                if (!registerUserResult.Success)
                {
                    return BadRequest(registerUserResult.ErrorMessage);
                }


                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword()
        {
            return Ok();
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            return Ok();
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken()
        {
            return Ok();
        }
    }
}
