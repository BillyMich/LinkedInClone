using LinkedInWebApi.Core;
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
                Password = user.UserPasswords?.Single(x => x.IsActive)?.Password
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

        private static UserPassword ToUserPassword(this string password)
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
    }
}
