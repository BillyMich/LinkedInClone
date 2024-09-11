using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class UserReadCommands : IUserReadCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;


        public UserReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }


        public async Task<UserDto?> CheckUserPasswordAsync(string email, string password)
        {
            var user = await _linkedInDbContext.Users
                .Include(u => u.UserPasswords) // Include related UserPasswords
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            var passwordIsValid = user.UserPasswords.Any(pass => pass.Password == password && pass.IsActive == true);

            if (!passwordIsValid)
            {
                return null;
            }

            return user.ToUserDto();
        }

        public async Task<FileDto> GetProfilePictureFromId(int id)
        {
            var photeProfile = await _linkedInDbContext.UserPhotoProfiles
                .FirstOrDefaultAsync(x => x.IsActive && x.UserId == id);

            return photeProfile.ToFileDto();

        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {

            var user = await _linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            return user.ToUserDto();

        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {

            var user = await _linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                //throw new ErrorException.NoUserFountWithGivenIdException();
            }
            return user.ToUserDto();

        }

        public async Task<List<UserDto>> GetUsersAsync(List<int>? ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return await _linkedInDbContext.Users.Select(x => x.ToUserDto()).ToListAsync();
            }

            return await _linkedInDbContext.Users.Where(x => ids.Contains(x.Id)).Select(x => x.ToUserDto()).ToListAsync();

        }

        public async Task<string> GetUsersToJsonAsync()
        {
            var users = await _linkedInDbContext.Users.ToListAsync();

            return users.SerializeToJson<User>();
        }

        public async Task<string> GetUsersToXMLAsync()
        {
            var users = await _linkedInDbContext.Users.ToListAsync();

            return users.SerializeToXml<User>();
        }
    }
}
