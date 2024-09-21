using LinkedInWebApi.Application.Extensions;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace LinkedInWebApi.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserReadCommands _userReadCommands;
        private readonly IUserUpdateCommands _userUpdateCommands;
        private readonly IUserInsertCommands _userInsertCommands;

        public UserService(IUserReadCommands userReadCommands, IUserUpdateCommands userUpdateCommands, IUserInsertCommands userInsertCommands)
        {
            _userReadCommands = userReadCommands;
            _userUpdateCommands = userUpdateCommands;
            _userInsertCommands = userInsertCommands;
        }

        public async Task<FileDto> GetProfilePictureFromId(int id)
        {
            return await _userReadCommands.GetProfilePictureFromId(id);
        }

        public async Task<UserDto> GetUser(int id, ClaimsIdentity claimsIdentity)
        {
            return await _userReadCommands.GetUserByIdAsync(id);
        }

        public async Task<List<UserDto>> GetUsers()
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

        public async Task UpdateProfilePictureAsync(IFormFile file, ClaimsIdentity claimsIdentity)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is invalid");
            }

            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var fileDto = file.ConvertToFileDto();

            await _userInsertCommands.UploadNewProfilePictureAsync(fileDto, curentUserId);


        }

        public async Task UpdateUserCVAsync(IFormFile file, ClaimsIdentity claimsIdentity)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is invalid");
            }

            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var fileDto = file.ConvertToFileDto();

            await _userInsertCommands.UploadNewCVAsync(fileDto, curentUserId);

        }

        public async Task UpdateUserSettingsAsync(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity)
        {
            var userId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var userToUpdate = await _userReadCommands.GetUserByIdWithPasswordAsync(userId);

            if (userToUpdate == null)
            {
                throw new ArgumentException("User not found");
            }

            if (userToUpdate.Password != updateUserSettingsDto.OldPassword)
            {
                throw new ArgumentException("Old password is invalid");
            }

            if (updateUserSettingsDto.Email != null)
            {
                await _userUpdateCommands.UpdateUserEmailAsync(userId, updateUserSettingsDto.Email);
            }

            if (updateUserSettingsDto.Password != null)
            {

                await _userUpdateCommands.UpdateUserPasswordAsync(userId, updateUserSettingsDto.Password);
            }

        }
    }
}
