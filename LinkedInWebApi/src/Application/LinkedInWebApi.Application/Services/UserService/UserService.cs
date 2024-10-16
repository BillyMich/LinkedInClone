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

        public async Task<List<UserEducationDto>> GetUserEducationAsync(int id, ClaimsIdentity identity)
        {
            return await _userReadCommands.GetUserEducationAsync(id);
        }

        public async Task<List<UserExperienceDto>> GetUserExperienceAsync(int id, ClaimsIdentity identity)
        {
            return await _userReadCommands.GetUserExperienceAsync(id);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return await _userReadCommands.GetUsersAsync(new List<int>());
        }

        public async Task<IActionResult> GetUsersToJsonAsync(List<int>? ids)
        {
            var usersList = await _userReadCommands.GetUserAllEntityAsync(ids);

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string jsonString = JsonConvert.SerializeObject(usersList, settings);
            var byteArray = Encoding.UTF8.GetBytes(jsonString);
            var stream = new MemoryStream(byteArray);

            return new FileStreamResult(stream, "application/json")
            {
                FileDownloadName = "UsersData.json"
            };
        }

        public async Task<IActionResult> GetUsersToXmlAsync(List<int>? ids)
        {
            var usersList = await _userReadCommands.GetUserAllEntityAsync(ids);

            string xmlContent = XMLSerialazationExtension.SerializeToXml(usersList);
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlContent);
            var stream = new MemoryStream(byteArray);

            return new FileStreamResult(stream, "application/xml")
            {
                FileDownloadName = "UsersData.xml"
            };
        }

        public Task<IActionResult> GetUserToJson(List<int>? ids)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUserEducationAsync(int userEducationId, ClaimsIdentity identity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(identity);
            await _userUpdateCommands.RemoveUserEducationAsync(userEducationId, curentUserId);
        }

        public async Task RemoveUserExperienceAsync(int userExperienceId, ClaimsIdentity identity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(identity);
            await _userUpdateCommands.RemoveUserrExperienceAsync(userExperienceId, curentUserId);
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

        public async Task UpdateUserEducationAsync(CreateUserEducationDto createUserEducation, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            await _userInsertCommands.InsertUserEducationAsync(createUserEducation, curentUserId);
        }

        public async Task UpdateUserExperienceAsync(CreateUserExperienceDto createUserExperience, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            await _userInsertCommands.InsertUserExperienceAsync(createUserExperience, curentUserId);

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
