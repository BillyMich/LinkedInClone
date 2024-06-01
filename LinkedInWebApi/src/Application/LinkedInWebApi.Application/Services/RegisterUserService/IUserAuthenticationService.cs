using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IUserAuthenticationService
    {

        Task<bool> RegisterUserAsync(UserRegisterDto registerDto);

        Task<List<Claim>> LoginUserService(UserLoginDto userLoginDto);
    }
}
