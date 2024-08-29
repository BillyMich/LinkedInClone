using LinkedInWebApi.Application.Extensions;
using LinkedInWebApi.Application.Services.ValidationServices;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    /// <summary>
    /// User Authentication Service
    /// </summary>
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserReadCommands _userReadCommands;
        private readonly IUserInsertCommands _userInsertCommands;
        private readonly JwtHandler _jwtHandler;
        private readonly IUserValidationServices _userValidationServices;
        public UserAuthenticationService(IUserReadCommands userReadCommands, IUserInsertCommands userInsertCommands, JwtHandler jwtHandler, IUserValidationServices userValidationServices)
        {
            _userReadCommands = userReadCommands;
            _jwtHandler = jwtHandler;
            _userInsertCommands = userInsertCommands;
            _userValidationServices = userValidationServices;
        }

        /// <summary>
        /// Login User Service
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        public async Task<string> LoginUserService(UserLoginDto userLoginDto)
        {

            var userDto = await _userReadCommands.CheckUserPasswordAsync(userLoginDto.Email, userLoginDto.Password);

            if (userDto == null)
            {
                throw ErrorException.AuthenticationException;
            }

            var token = _jwtHandler.GenerateToken(userDto);
            return token;

        }

        /// <summary>
        /// Register User Service
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUserAsync(UserRegisterDto registerDto)
        {

            await _userValidationServices.IsValidUserToRegister(registerDto);


            var registerUserResult = await _userInsertCommands.RegisterUserAsync(registerDto.ToUserDto());

            return registerUserResult;

        }

    }
}
