using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Extensions
{
    /// <summary>
    /// User extensions
    /// </summary>
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
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }
    }
}
