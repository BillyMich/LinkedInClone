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

        Task<IActionResult> GetUsersToXML(List<int>? ids);

        Task<IActionResult> GetUsersToJson(List<int>? ids);

        Task UpdateProfilePictureAsync(IFormFile file, ClaimsIdentity claimsIdentity);

        Task<FileDto> GetProfilePictureFromId(int id);

        Task UpdateUserSettingsAsync(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity);
        Task UpdateUserCVAsync(IFormFile file, ClaimsIdentity identity);
        Task UpdateUserExperienceAsync(CreateUserExperience createUserExperience, ClaimsIdentity identity);
        Task UpdateUserEducationAsync(CreateUserEducation createUserEducation, ClaimsIdentity identity);
    }
}
