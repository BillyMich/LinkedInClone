using LinkedInWebApi.Core;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Core.Extensions;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Xml.Serialization;

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

        public async Task<List<User>> GetUserAllEntityAsync(List<int>? ids)
        {

            var a = await _linkedInDbContext.Users
                .Include(x => x.UserEducations)
                .Include(x => x.AdvertisementApplies)
                .Include(x => x.Advertisements)
                .Include(x => x.ContactRequestUserRequests)
                .Include(x => x.ContactRequestUserResivers)
                .Include(x => x.PostComments)
                .Include(x => x.PostReactions)
                .Include(x => x.Posts)
                .Include(x => x.UserExperiences)
                .ToListAsync();

            var xmlSerializer = new XmlSerializer(typeof(User));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                xmlSerializer.Serialize(xmlWriter, a, namespaces);
                var s = stringWriter.ToString();

                return a;
            }


            return await _linkedInDbContext.Users.Where(x => ids.Contains(x.Id)).Include(x => x.UserEducations)
                    .Include(x => x.AdvertisementApplies)
                    .Include(x => x.Advertisements)
                    .Include(x => x.ContactRequestUserRequests)
                    .Include(x => x.ContactRequestUserResivers)
                    .Include(x => x.PostComments)
                    .Include(x => x.PostReactions)
                    .Include(x => x.Posts)
                    .Include(x => x.UserExperiences)
                    .ToListAsync();
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

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {

            var user = await _linkedInDbContext.Users.SingleAsync(x => x.Id == userId && x.IsActive);

            if (user == null)
            {
                throw ErrorException.NoUserFountWithGivenIdException;
            }

            return user.ToUserDto();

        }

        public async Task<UserDto> GetUserByIdWithPasswordAsync(int userId)
        {
            var user = await _linkedInDbContext.Users.Include(x => x.UserPasswords)
                .SingleAsync(x => x.Id == userId && x.IsActive);

            return user.ToUserDto();
        }

        public Task<List<UserEducationDto>> GetUserEducationAsync(int id)
        {
            var userEducation = _linkedInDbContext.UserEducations
                .Where(x => x.UserId == id)
                .Select(x => x.ToUserEducationDto())
                .ToListAsync();

            return userEducation;
        }

        public Task<List<UserExperienceDto>> GetUserExperienceAsync(int id)
        {
            var userExperience = _linkedInDbContext.UserExperiences
                .Where(x => x.UserId == id)
                .Select(x => x.ToUserExperienceDto())
                .ToListAsync();

            return userExperience;
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

    }
}
