using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services.ValidationServices
{
    public class UserValidationsServices : IUserValidationServices
    {
        IUserReadCommands _userReadCommands;

        public UserValidationsServices(IUserReadCommands userReadCommands)
        {
            _userReadCommands = userReadCommands;
        }

        public async Task<bool> IsValidUserToRegister(UserRegisterDto userRegisterDto)
        {

            var userWithSameEmailExist = await _userReadCommands.GetUserByEmailAsync(userRegisterDto.Email);

            if (userWithSameEmailExist != null)
            {
                return false;
            }

            //todo : add more validations

            return true;

        }
    }
}
