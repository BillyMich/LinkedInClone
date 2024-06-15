using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class UserReadCommands : IUserReadCommands
    {

        private readonly LinkedInDbContext linkedInDbContext;


        public UserReadCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }


        public async Task<UserDto?> CheckUserPasswordAsync(string email, string password)
        {
            var user = await linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return null;
            }

            return user.ToUserDto();
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {

            var user = await linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            return user.ToUserDto();

        }
    }
}
