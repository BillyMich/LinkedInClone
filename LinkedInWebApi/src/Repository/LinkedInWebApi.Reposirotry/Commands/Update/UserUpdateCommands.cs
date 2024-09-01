using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands.Update
{
    public class UserUpdateCommands : IUserUpdateCommands
    {

        private readonly LinkedInDbContext linkedInDbContext;


        public UserUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {

            var user = await linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);

            if (user == null)
            {
                //throw new ErrorException.NoUserFountWithGivenIdException();
            }


            user.UpdateUserFromDto(userDto);

            try
            {
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
