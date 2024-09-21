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


        public Task<IActionResult> GetUsersToJson(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetUsersToXMLAsync(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUsersToXML(ids);
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
    }
}
