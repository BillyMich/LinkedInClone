using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class UserInsertCommands : IUserInsertCommands
    {

        private readonly LinkedInDbContext linkedInDbContext;


        public UserInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }


        public async Task<bool> RegisterUserAsync(UserDto userDto)
        {

            try
            {
                await linkedInDbContext.Users.AddAsync(userDto.ToUserRegister());
                await linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
