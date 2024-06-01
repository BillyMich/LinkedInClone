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
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                Phone = user.Phone,
            };
        }


    }
}
