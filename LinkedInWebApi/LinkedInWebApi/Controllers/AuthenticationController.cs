using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInWebApi.Controllers
{
    /// <summary>
    /// Controller for authentication
    /// </summary>
    [Route("api/")]
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
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto)
        {
            try
            {

                var generatedToken = await _authenticationHandler.LoginUserHandler(userLoginDto);

                if (generatedToken == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                var response = new
                {
                    access_token = generatedToken,
                    token_type = "bearer",
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Register
        /// </summary>
        /// <returns>Returns 204 if the registration completed successfully and if not
        /// it will return 400 with the error message depending on the error
        /// </returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                var registerUserResult = await _authenticationHandler.RegisterUserHandler(userRegisterDto);

                if (!registerUserResult)
                {
                    return BadRequest("Something wrong happed");
                }

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
