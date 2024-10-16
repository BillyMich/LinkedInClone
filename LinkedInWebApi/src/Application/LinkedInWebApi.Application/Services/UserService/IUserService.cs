using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id, ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetUsers();

        Task<IActionResult> GetUsersToXmlAsync(List<int>? ids);

        Task<IActionResult> GetUsersToJsonAsync(List<int>? ids);

        Task UpdateProfilePictureAsync(IFormFile file, ClaimsIdentity claimsIdentity);

        Task<FileDto> GetProfilePictureFromId(int id);

        Task UpdateUserSettingsAsync(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity);
        Task UpdateUserCVAsync(IFormFile file, ClaimsIdentity identity);
        Task UpdateUserExperienceAsync(CreateUserExperienceDto createUserExperience, ClaimsIdentity identity);
        Task UpdateUserEducationAsync(CreateUserEducationDto createUserEducation, ClaimsIdentity identity);
        Task RemoveUserExperienceAsync(int userExperienceId, ClaimsIdentity identity);
        Task RemoveUserEducationAsync(int userEducationId, ClaimsIdentity identity);
        Task<List<UserEducationDto>> GetUserEducationAsync(int id, ClaimsIdentity identity);
        Task<List<UserExperienceDto>> GetUserExperienceAsync(int id, ClaimsIdentity identity);
        Task<IActionResult> GetUserToJson(List<int>? ids);
    }
}
