using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entities;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class UserExtensions
    {

        public static UserDto ToUserDto(this User user)
        {

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



    }
}
