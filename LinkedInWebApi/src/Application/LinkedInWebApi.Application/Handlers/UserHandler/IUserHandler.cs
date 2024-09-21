using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public interface IUserHandler
    {

        Task<UserDto?> GetUserHandlerAsync(int id, ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetUsersHandlerAsync(ClaimsIdentity claimsIdentity);

        Task<IActionResult> GetUsersToXMLAsync(List<int>? ids, ClaimsIdentity claimsIdentity);

        Task<IActionResult> GetUsersToJson(List<int>? ids, ClaimsIdentity claimsIdentity);

        Task UpdateUserSettingsAsync(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity);

        Task UpdateProfilePictureAsync(IFormFile file, ClaimsIdentity claimsIdentity);

        Task<FileDto> GetProfilePictureFromIdAsync(int id);
        Task UpdateUserCVAsync(IFormFile file, ClaimsIdentity identity);
    }
}
