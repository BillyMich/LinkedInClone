using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserUpdateCommands
    {

        Task<bool> UpdateUserAsync(UserDto userDto);

        Task<bool> UpdateProfilePicture(int userId, ImageModelDto imageModelDto);
    }
}
