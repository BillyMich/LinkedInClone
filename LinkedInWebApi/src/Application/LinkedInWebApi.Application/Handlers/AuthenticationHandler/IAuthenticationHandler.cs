using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IAuthenticationHandler
    {

        Task<bool> RegisterUserHandler(UserRegisterDto registerDto);

        Task<string> LoginUserHandler(UserLoginDto registerDto);

    }
}
