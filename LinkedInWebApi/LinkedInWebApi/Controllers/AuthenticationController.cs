using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [AllowAnonymous]

        public async Task<ActionResult<List<Claim>>> Login(UserLoginDto userLoginDto)
        {
            try
            {

                var userClaims = await _authenticationHandler.LoginUserHandler(userLoginDto);

                if (userClaims == null)
                {
                    return BadRequest("Invalid email or password");
                }

                return Ok();

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
