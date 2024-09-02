using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public interface IUserHandler
    {

        /// <summary>
        /// Get User Handler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto?> GetUserHandler(int id);

        /// <summary>
        /// Get Users Handler
        /// </summary>
        /// <returns></returns>
        Task<List<UserDto>> GetUsersHandler();

        /// <summary> Returns then user list as XML </summary>
        Task<IActionResult> GetUsersToXML(List<int>? ids);

        Task<IActionResult> GetUsersToJson(List<int>? ids);

        Task UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto);

        Task<List<UserDto>> GetConectedUsersHandler();

        Task UpdateProfilePicture(int userId, IFormFile file);
    }
}
