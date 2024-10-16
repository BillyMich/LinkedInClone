using LinkedInWebApi.Application.Services.UserService;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserService _userService;

        public UserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<List<UserDto>> GetUsersHandlerAsync(ClaimsIdentity claimsIdentity)
        {
            return _userService.GetUsers();
        }

        public async Task<UserDto?> GetUserHandlerAsync(int id, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUser(id, claimsIdentity);
        }


        public async Task<IActionResult> GetUsersToJsonAsync(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUsersToJsonAsync(ids);
        }

        public async Task<IActionResult> GetUsersToXMLAsync(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUsersToXmlAsync(ids);
        }


        public async Task UpdateProfilePictureAsync(IFormFile file, ClaimsIdentity claimsIdentity)
        {
            await _userService.UpdateProfilePictureAsync(file, claimsIdentity);
        }


        public async Task UpdateUserSettingsAsync(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity)
        {
            await _userService.UpdateUserSettingsAsync(updateUserSettingsDto, claimsIdentity);
        }

        public async Task<FileDto> GetProfilePictureFromIdAsync(int id)
        {
            return await _userService.GetProfilePictureFromId(id);
        }

        public async Task UpdateUserCVAsync(IFormFile file, ClaimsIdentity identity)
        {
            await _userService.UpdateUserCVAsync(file, identity);
        }

        public async Task UpdateUserExperienceAsync(CreateUserExperienceDto createUserExperience, ClaimsIdentity identity)
        {
            await _userService.UpdateUserExperienceAsync(createUserExperience, identity);
        }

        public async Task UpdateUserEducationAsync(CreateUserEducationDto createUserEducation, ClaimsIdentity identity)
        {
            await _userService.UpdateUserEducationAsync(createUserEducation, identity);
        }

        public async Task RemoveUserExperienceAsync(int userExperienceId, ClaimsIdentity identity)
        {
            await _userService.RemoveUserExperienceAsync(userExperienceId, identity);
        }

        public async Task RemoveUpdateUserEducationAsync(int userEducationId, ClaimsIdentity identity)
        {
            await _userService.RemoveUserEducationAsync(userEducationId, identity);
        }

        public async Task<List<UserEducationDto>> GetUserEducationHandlerAsync(int id, ClaimsIdentity identity)
        {
            return await _userService.GetUserEducationAsync(id, identity);
        }

        public async Task<List<UserExperienceDto>> GetUserExperienceHandlerAsync(int id, ClaimsIdentity identity)
        {
            return await _userService.GetUserExperienceAsync(id, identity);
        }
    }
}
