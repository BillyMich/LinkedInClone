using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entities;
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

        public async Task<UserDto> GetUserByIdAsync(int id)
        {

            var user = await linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }
            return user.ToUserDto();

        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await linkedInDbContext.Users.ToListAsync();

            // TODO: Implement extension for that job
            return users.Select(x => x.ToUserDto()).ToList();

        }

        public async Task<string> GetUsersToJsonAsync()
        {
            var users = await linkedInDbContext.Users.ToListAsync();

            return users.SerializeToJson<User>();
        }

        public async Task<string> GetUsersToXMLAsync()
        {
            var users = await linkedInDbContext.Users.ToListAsync();

            return users.SerializeToXml<User>();
        }
    }
}
