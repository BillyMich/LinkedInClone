using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public interface IUserHandler
    {

        Task<UserDto?> GetUserHandler(int id, ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetUsersHandler(ClaimsIdentity claimsIdentity);

        Task<IActionResult> GetUsersToXML(List<int>? ids, ClaimsIdentity claimsIdentity);

        Task<IActionResult> GetUsersToJson(List<int>? ids, ClaimsIdentity claimsIdentity);

        Task UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity);

        Task UpdateProfilePicture(IFormFile file, ClaimsIdentity claimsIdentity);

        Task<FileDto> GetProfilePictureFromId(int id);
    }
}
