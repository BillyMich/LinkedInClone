using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);

        Task<List<UserDto>> GetUsers();

        Task<string> GetUsersToXML();

        Task<string> GetUsersToJson();

        Task<bool> UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto);
    }
}
