using LinkedInWebApi.Application.Extensions;
using LinkedInWebApi.Application.Services.ValidationServices;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
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

        public async Task<string> LoginUserService(UserLoginDto userLoginDto)
        {

            var userDto = await _userReadCommands.CheckUserPasswordAsync(userLoginDto.Email, userLoginDto.Password);

            if (userDto == null)
            {
                return null;
            }

            var token = _jwtHandler.GenerateToken(userDto);

            return token;

        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto registerDto)
        {

            var isValidToRegister = await _userValidationServices.IsValidUserToRegister(registerDto);

            if (!isValidToRegister)
            {
                return false;
            }

            var registerUserResult = await _userInsertCommands.RegisterUserAsync(registerDto.ToUserDto());

            return registerUserResult;

        }

    }
}
