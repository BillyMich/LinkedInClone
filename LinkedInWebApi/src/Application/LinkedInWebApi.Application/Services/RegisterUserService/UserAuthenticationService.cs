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

        public UserAuthenticationService(IUserReadCommands userReadCommands, IUserInsertCommands userInsertCommands, JwtHandler jwtHandler)
        {
            _userReadCommands = userReadCommands;
            _jwtHandler = jwtHandler;
            _userInsertCommands = userInsertCommands;
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


            var userDto = new UserDto
            {
                Username = registerDto.UserName,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Password = registerDto.Password,
                Role = Role.User,
                Email = registerDto.Email,
                IsActive = true,
                Phone = registerDto.Phone,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
            };


            var registerUserResult = await _userInsertCommands.RegisterUserAsync(userDto);
            return registerUserResult;

        }

    }
}
