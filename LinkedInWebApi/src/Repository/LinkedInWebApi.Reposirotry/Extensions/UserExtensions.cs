﻿using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    /// <summary>
    /// User Extensions
    /// </summary>
    public static class UserExtensions
    {

        /// <summary>
        /// Convert User to UserDto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserDto ToUserDto(this User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {

                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                Role = (Role)user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Password = user.UserPasswords?.SingleOrDefault(x => x.IsActive)?.Password
            };
        }

        /// <summary>
        /// Convert UserDto to User
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static User ToUserRegister(this UserDto userDto)
        {

            return new User
            {

                Id = userDto.Id,
                Username = userDto.Username,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Role = (byte)userDto.Role,
                IsActive = userDto.IsActive,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                UserPasswords = new List<UserPassword> { userDto.Password.ToUserPassword() }
            };
        }

        public static UserPassword ToUserPassword(this string password)
        {
            return new UserPassword
            {
                Password = password,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                IsActive = true

            };
        }


        /// <summary>
        /// Convert List<User> to List<UserDto>
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<UserDto> ToUserDtoList(this List<User> users)
        {
            return users.Select(x => x.ToUserDto()).ToList();
        }


        public static User UpdateUserFromDto(this User user, UserDto userDto)
        {
            user.Username = userDto.Username;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
            user.Role = (byte)userDto.Role;
            user.IsActive = userDto.IsActive;
            user.UpdatedAt = DateTimeOffset.Now;

            return user;
        }

        public static UserPhotoProfile ToUserPhotoProfile(this FileDto fileDto, int userId)
        {
            return new UserPhotoProfile
            {
                UserId = userId,
                FileName = fileDto.FileName,
                DataOfFile = fileDto.DataOfFile,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

        public static FileDto ToFileDto(this UserPhotoProfile? userPhotoProfiles)
        {

            return new FileDto
            {
                FileName = userPhotoProfiles?.FileName,
                DataOfFile = userPhotoProfiles?.DataOfFile,

            };
        }

        public static UserCv ToUserCV(this FileDto fileDto, int userId)
        {
            return new UserCv
            {
                UserId = userId,
                FileName = fileDto.FileName,
                DataOfFile = fileDto.DataOfFile,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

        public static UserEducation ToUserEducation(this CreateUserEducationDto createUserEducation, int userId)
        {
            return new UserEducation
            {
                UserId = userId,
                Name = createUserEducation.DegreeTitle,
                Description = createUserEducation.Description,
                IsPublic = createUserEducation.IsPublic,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                EducationTypeId = createUserEducation.EducationTypeId
            };
        }

        public static UserEducationDto ToUserEducationDto(this UserEducation userEducation)
        {
            return new UserEducationDto
            {
                Id = userEducation.Id,
                UserId = userEducation.UserId,
                Name = userEducation.Name,
                Description = userEducation.Description,
                IsPublic = userEducation.IsPublic,
                IsActive = userEducation.IsActive,
                CreatedAt = userEducation.CreatedAt,
                UpdatedAt = userEducation.UpdatedAt,
                EducationTypeId = userEducation.EducationTypeId
            };
        }

        public static UserExperience ToUserExperience(this CreateUserExperienceDto createUserEducation, int userId)
        {
            return new UserExperience
            {
                UserId = userId,
                Title = createUserEducation.Title,
                FreeTxt = createUserEducation.FreeTxt,
                IsPublic = createUserEducation.IsPublic,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                StartedAt = createUserEducation.StartedAt,
                EndedAt = createUserEducation.EndedAt
            };
        }

        public static UserExperienceDto ToUserExperienceDto(this UserExperience userExperience)
        {
            return new UserExperienceDto
            {
                Id = userExperience.Id,
                UserId = userExperience.UserId,
                Title = userExperience.Title,
                FreeTxt = userExperience.FreeTxt,
                IsPublic = userExperience.IsPublic,
                IsActive = userExperience.IsActive,
                CreatedAt = userExperience.CreatedAt,
                UpdatedAt = userExperience.UpdatedAt,
                StartedAt = userExperience.StartedAt,
                EndedAt = userExperience.EndedAt
            };
        }
    }
}
