using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserReadCommands _userReadCommands;
        private readonly JwtHandler _jwtHandler;

        public UserAuthenticationService(IUserReadCommands userReadCommands, JwtHandler jwtHandler)
        {
            _userReadCommands = userReadCommands;
            _jwtHandler = jwtHandler;
        }

        public async Task<List<Claim>> LoginUserService(UserLoginDto userLoginDto)
        {

            var userDto = await _userReadCommands.CheckUserPasswordAsync(userLoginDto.Email, userLoginDto.Password);

            var listClaims = _jwtHandler.GetClaims(userDto);

            return listClaims;

        }

        public Task<bool> RegisterUserAsync(UserRegisterDto registerDto)
        {

            throw new NotImplementedException();

        }

    }
}
