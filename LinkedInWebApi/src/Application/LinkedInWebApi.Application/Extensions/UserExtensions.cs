using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Extensions
{
    public static class UserExtensions
    {

        public static UserDto ToUserDto(this UserRegisterDto registerDto)
        {
            return new UserDto
            {
                Username = registerDto.UserName,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Password = registerDto.Password,
                Role = Role.User,
                Email = registerDto.Email,
                IsActive = true,
                Phone = registerDto.Phone,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
            };
        }
    }
}
