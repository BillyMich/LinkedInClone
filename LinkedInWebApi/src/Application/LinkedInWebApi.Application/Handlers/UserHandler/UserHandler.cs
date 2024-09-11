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

        public Task<List<UserDto>> GetUsersHandler(ClaimsIdentity claimsIdentity)
        {
            return _userService.GetUsers();
        }

        public async Task<UserDto?> GetUserHandler(int id, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUser(id, claimsIdentity);
        }


        public Task<IActionResult> GetUsersToJson(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetUsersToXML(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            return await _userService.GetUsersToXML(ids);
        }


        public async Task UpdateProfilePicture(IFormFile file, ClaimsIdentity claimsIdentity)
        {
            await _userService.UpdateProfilePicture(file, claimsIdentity);
        }


        public Task UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDto> GetProfilePictureFromId(int id)
        {
            return await _userService.GetProfilePictureFromId(id);
        }
    }
}
