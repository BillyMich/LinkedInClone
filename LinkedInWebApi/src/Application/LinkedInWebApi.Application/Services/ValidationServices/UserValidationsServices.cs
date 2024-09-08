using LinkedInWebApi.Core;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    public class UserValidationsServices : IUserValidationServices
    {
        IUserReadCommands _userReadCommands;

        public UserValidationsServices(IUserReadCommands userReadCommands)
        {
            _userReadCommands = userReadCommands;
        }

        public async Task IsValidUserToRegister(UserRegisterDto userRegisterDto)
        {

            //TODO: Add more validations
            var userWithSameEmailExist = await _userReadCommands.GetUserByEmailAsync(userRegisterDto.Email);

            if (userWithSameEmailExist != null)
            {
                throw ErrorException.EmailAlreadyExistsFromAnotherUserException;
            }



        }
    }
}
