using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserUpdateCommands
    {

        Task<bool> UpdateUserAsync(UserDto userDto);

        Task<bool> UpdateProfilePicture(int userId, ImageModelDto imageModelDto);
        Task<bool> UpdateUserEmailAsync(int userId, string email);
        Task<bool> UpdateUserPasswordAsync(int userId, string password);
    }
}
