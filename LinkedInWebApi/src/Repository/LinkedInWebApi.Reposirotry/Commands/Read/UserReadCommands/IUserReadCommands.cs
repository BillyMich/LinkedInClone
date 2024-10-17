using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserReadCommands
    {
        Task<UserDto?> GetUserByEmailAsync(string email);

        Task<UserDto?> CheckUserPasswordAsync(string email, string password);

        Task<UserDto?> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetUsersAsync(List<int>? ints);

        Task<List<User>> GetUserAllEntityAsync(List<int>? ints);

        Task<string> GetUsersToJsonAsync();

        Task<FileDto> GetProfilePictureFromId(int id);

        Task<UserDto> GetUserByIdWithPasswordAsync(int userId);
        Task<List<UserEducationDto>> GetUserEducationAsync(int id);
        Task<List<UserExperienceDto>> GetUserExperienceAsync(int id);
    }
}
