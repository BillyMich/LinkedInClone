using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public class AuthenticationHandler : IAuthenticationHandler
    {

        private readonly IUserAuthenticationService _userAuthenticationService;


        public AuthenticationHandler(IUserAuthenticationService registerUserService)
        {
            _userAuthenticationService = registerUserService;
        }

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
