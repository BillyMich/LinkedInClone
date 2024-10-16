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
        Task UpdateUserExperienceAsync(CreateUserExperienceDto createUserExperience, ClaimsIdentity identity);
        Task UpdateUserEducationAsync(CreateUserEducationDto createUserEducation, ClaimsIdentity identity);
        Task RemoveUserExperienceAsync(int userExperienceId, ClaimsIdentity identity);
        Task RemoveUpdateUserEducationAsync(int userEducationId, ClaimsIdentity identity);
        Task<List<UserEducationDto>> GetUserEducationHandlerAsync(int id, ClaimsIdentity identity);
        Task<List<UserExperienceDto>> GetUserExperienceHandlerAsync(int id, ClaimsIdentity identity);
    }
}
