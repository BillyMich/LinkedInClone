using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IAuthenticationHandler
    {

        Task<bool> RegisterUserHandler(UserRegisterDto registerDto);

        Task<List<Claim>> LoginUserHandler(UserLoginDto registerDto);

    }
}
