using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public class UserHandler : IUserHandler
    {
        IUserReadCommands _userReadCommands;

        public UserHandler(IUserReadCommands userReadCommands)
        {
            _userReadCommands = userReadCommands;
        }
        public async Task<UserDto?> GetUserHandler(int id)
        {
            return await _userReadCommands.GetUserByIdAsync(id);
        }

        public async Task<List<UserDto>> GetUsersHandler()
        {
            return await _userReadCommands.GetUsersAsync();
        }

        public async Task<string> GetUsersToJson()
        {
            return await _userReadCommands.GetUsersToJsonAsync();
        }

        public async Task<string> GetUsersToXML()
        {
            return await _userReadCommands.GetUsersToXMLAsync();
        }
    }
}
