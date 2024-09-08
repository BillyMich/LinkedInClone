﻿using LinkedInWebApi.Application.Services.UserService;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Reposirotry.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserService _userService;
        private readonly IUserReadCommands _userReadCommands;
        private readonly IUserUpdateCommands _userUpdateCommands;


        public UserHandler(IUserService userService, IUserReadCommands userReadCommands, IUserUpdateCommands userUpdateCommands)
        {
            _userService = userService;
            _userReadCommands = userReadCommands;
            _userUpdateCommands = userUpdateCommands;
        }

        public Task<List<UserDto>> GetConectedUsersHandler()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetConectedUsersHandler(ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> GetUserHandler(int id, ClaimsIdentity claimsIdentity)
        {
            return await _userReadCommands.GetUserByIdAsync(id);
        }

        public async Task<List<UserDto>> GetUsersHandler()
        {
            return await _userReadCommands.GetUsersAsync(new List<int>());
        }

        public Task<List<UserDto>> GetUsersHandler(ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
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

        public Task<IActionResult> GetUsersToJson(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
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

        public Task<IActionResult> GetUsersToXML(List<int>? ids, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProfilePicture(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var image = new ImageModelDto
                    {
                        FileName = file.FileName,
                        DataOfFile = memoryStream.ToArray()
                    };
                }

            throw new NotImplementedException();
        }

        public Task UpdateProfilePicture(IFormFile file, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto)
        {

            var userToUpdate = await _userReadCommands.GetUserByEmailAsync(updateUserSettingsDto.Email);

            if (userToUpdate == null)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            userToUpdate.Email = updateUserSettingsDto.Email;
            userToUpdate.Password = updateUserSettingsDto.Password;

            await _userUpdateCommands.UpdateUserAsync(userToUpdate);

        }

        public Task UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
