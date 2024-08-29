using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IAuthenticationHandler
    {

        /// <summary>
        /// Register User Handler
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        Task<bool> RegisterUserHandler(UserRegisterDto registerDto);

        /// <summary>
        /// Login User Handler
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        Task<string> LoginUserHandler(UserLoginDto registerDto);

    }
}
