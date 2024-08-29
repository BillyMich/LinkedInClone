using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserReadCommands _userReadCommands;

        public Task<UserDto> GetUser(int id)
        {
            return _userReadCommands.GetUserByIdAsync(id);
        }

        public Task<List<UserDto>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsersToJson()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsersToXML()
        {
            throw new NotImplementedException();
        }
    }
}
