using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserReadCommands
    {
        Task<UserDto> GetUserByEmailAsync(string email);

        Task<UserDto> CheckUserPasswordAsync(string email, string password);
    }
}
