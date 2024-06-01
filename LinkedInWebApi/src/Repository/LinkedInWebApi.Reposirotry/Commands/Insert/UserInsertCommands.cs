using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entities;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class UserInsertCommands : IUserInsertCommands
    {

        private readonly LinkedInDbContext linkedInDbContext;


        public UserInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }


        public async Task<bool> RegisterUserAsync(UserRegisterDto registerDto)
        {

            try
            {

                linkedInDbContext.Users.Add(new User
                {
                    Name = registerDto.Name,
                    SurName = registerDto.SurName,
                    Phone = registerDto.Phone,
                    Email = registerDto.Email,
                    Password = registerDto.Password
                });


                await linkedInDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }



            throw new NotImplementedException();
        }
    }
}
