using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserInsertCommands
    {

        Task<bool> RegisterUserAsync(UserDto registerDto);

    }
}
