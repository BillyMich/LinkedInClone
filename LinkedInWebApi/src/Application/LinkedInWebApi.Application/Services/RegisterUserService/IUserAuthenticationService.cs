using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services
{
    public interface IUserAuthenticationService
    {
        /// <summary>
        /// Register User Service
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        Task<bool> RegisterUserAsync(UserRegisterDto registerDto);

        /// <summary>
        /// Login User Service
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        Task<string> LoginUserService(UserLoginDto userLoginDto);
    }
}
