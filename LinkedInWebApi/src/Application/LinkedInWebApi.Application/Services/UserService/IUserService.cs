using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id, ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetUsers();

        Task<string> GetUsersToXML();

        Task<string> GetUsersToJson();

        Task UpdateUserSettingsAsync(int id, UpdateUserSettingsDto updateUserSettingsDto);
    }
}
