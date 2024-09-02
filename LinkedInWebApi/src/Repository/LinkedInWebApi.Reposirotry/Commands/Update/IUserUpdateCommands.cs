using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserUpdateCommands
    {

        Task<bool> UpdateUserAsync(UserDto userDto);
    }
}
