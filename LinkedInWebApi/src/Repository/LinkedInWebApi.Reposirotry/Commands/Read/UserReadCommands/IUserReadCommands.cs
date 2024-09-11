using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserReadCommands
    {
        Task<UserDto?> GetUserByEmailAsync(string email);

        Task<UserDto?> CheckUserPasswordAsync(string email, string password);

        Task<UserDto?> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetUsersAsync(List<int>? ints);

        Task<string> GetUsersToJsonAsync();

        Task<string> GetUsersToXMLAsync();

        Task<FileDto> GetProfilePictureFromId(int id);

    }
}
