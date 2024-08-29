using LinkedInWebApi.Application.Services.UserService;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Reposirotry.Commands;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public class UserHandler : IUserHandler
    {
        IUserReadCommands _userReadCommands;
        IUserService _userService;

        public UserHandler(IUserReadCommands userReadCommands, IUserService userService)
        {
            _userReadCommands = userReadCommands;
            _userService = userService;
        }
        public async Task<UserDto?> GetUserHandler(int id)
        {
            return await _userReadCommands.GetUserByIdAsync(id);
        }

        public async Task<List<UserDto>> GetUsersHandler()
        {
            return await _userReadCommands.GetUsersAsync(new List<int>());
        }

        public async Task<IActionResult> GetUsersToJson(List<int>? ids)
        {

            var usersList = await _userReadCommands.GetUsersAsync(ids);

            var json = JsonConvert.SerializeObject(usersList);
            var byteArray = Encoding.UTF8.GetBytes(json);
            var stream = new MemoryStream(byteArray);

            return new FileStreamResult(stream, "application/json")
            {
                FileDownloadName = "UsersData.json"
            };
        }

        public async Task<IActionResult> GetUsersToXML(List<int>? ids)
        {

            var usersList = await _userReadCommands.GetUsersAsync(ids);

            string xmlContent = await XMLSerialazationExtension.GenerateUserXmlAsync(usersList);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(xmlContent);
            return new FileContentResult(byteArray, "application/xml")
            {
                FileDownloadName = "users.xml"
            };
        }

        public Task<bool> UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto)
        {
            throw new NotImplementedException();
        }
    }
}
