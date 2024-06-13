using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services
{
    public interface IUserAuthenticationService
    {

        Task<bool> RegisterUserAsync(UserRegisterDto registerDto);

        Task<string> LoginUserService(UserLoginDto userLoginDto);
    }
}
