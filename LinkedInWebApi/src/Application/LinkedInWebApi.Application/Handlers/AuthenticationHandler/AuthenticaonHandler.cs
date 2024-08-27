using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    /// <summary>
    /// Authentication Handler
    /// </summary>
    public class AuthenticationHandler : IAuthenticationHandler
    {

        private readonly IUserAuthenticationService _userAuthenticationService;


        public AuthenticationHandler(IUserAuthenticationService registerUserService)
        {
            _userAuthenticationService = registerUserService;
        }

        /// <summary>
        /// Login User Handler
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        public Task<string> LoginUserHandler(UserLoginDto registerDto)
        {

            return _userAuthenticationService.LoginUserService(registerDto);
        }

        /// <summary>
        /// Register User Handler
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        public Task<bool> RegisterUserHandler(UserRegisterDto registerDto)
        {
            return _userAuthenticationService.RegisterUserAsync(registerDto);
        }
    }
}
