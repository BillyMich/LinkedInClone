using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entities;

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
                DateCreated = user.DateCreated,
                DateUpdated = user.DateUpdated,
            };
        }

        /// <summary>
        /// Convert UserDto to User
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static User ToUser(this UserDto userDto)
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
                Password = userDto.Password,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
            };
        }

        /// <summary>
        /// Convert List<UserDto> to List<User>
        /// </summary>
        /// <param name="userDtos"></param>
        /// <returns></returns>
        public static List<User> ToUserList(this List<UserDto> userDtos)
        {
            return userDtos.Select(x => x.ToUser()).ToList();
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

    }
}
