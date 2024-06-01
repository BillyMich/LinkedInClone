using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public class AuthenticationHandler : IAuthenticationHandler
    {

        private readonly IUserAuthenticationService _userAuthenticationService;


        public AuthenticationHandler(IUserAuthenticationService registerUserService)
        {
            _userAuthenticationService = registerUserService;
        }

        public Task<List<Claim>> LoginUserHandler(UserLoginDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserHandler(UserRegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
