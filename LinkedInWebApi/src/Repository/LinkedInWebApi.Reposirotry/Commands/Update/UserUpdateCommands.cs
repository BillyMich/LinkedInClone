using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class UserUpdateCommands : IUserUpdateCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        public UserUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task RemoveUserEducationAsync(int userEducationId, int curentUserId)
        {
            var findEducationById = await _linkedInDbContext.UserEducations.FirstOrDefaultAsync(x => x.Id == userEducationId);

            if (findEducationById == null)
            {
                //throw new ErrorException.NoUserEducationFoundWithGivenIdException();
            }

            findEducationById.IsActive = false;
            _linkedInDbContext.Update(findEducationById);
            await _linkedInDbContext.SaveChangesAsync();

        }

        public async Task RemoveUserrExperienceAsync(int userExperienceId, int curentUserId)
        {
            var findExperienceById = _linkedInDbContext.UserExperiences.FirstOrDefault(x => x.Id == userExperienceId);

            if (findExperienceById == null)
            {
                //throw new ErrorException.NoUserExperienceFoundWithGivenIdException();
            }

            findExperienceById.IsActive = false;
            _linkedInDbContext.Update(findExperienceById);
            await _linkedInDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProfilePicture(int userId, ImageModelDto imageModelDto)
        {
            var findExistingUserProfilePicture = await _linkedInDbContext.UserPhotoProfiles.FirstOrDefaultAsync(x => x.UserId == userId);

            findExistingUserProfilePicture.IsActive = false;

            await _linkedInDbContext.UserPhotoProfiles.AddAsync(new UserPhotoProfile
            {
                UserId = userId,
                FileName = imageModelDto.FileName,
                DataOfFile = imageModelDto.DataOfFile,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            });

            await _linkedInDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {
            var user = await _linkedInDbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);

            if (user == null)
            {
                //throw new ErrorException.NoUserFountWithGivenIdException();
            }

            user.UpdateUserFromDto(userDto);

            try
            {
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUserEmailAsync(int userId, string email)
        {
            var user = await _linkedInDbContext.Users.SingleAsync(x => x.Id == userId && x.IsActive);
            user.Email = email;
            _linkedInDbContext.Update(user);
            await _linkedInDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserPasswordAsync(int userId, string password)
        {
            var user = await _linkedInDbContext.Users.Include(x => x.UserPasswords)
                .SingleAsync(x => x.Id == userId && x.IsActive);

            user.UserPasswords.Single(x => x.IsActive).IsActive = false;
            var userPassword = password.ToUserPassword();
            user.UserPasswords.Add(userPassword);

            _linkedInDbContext.Update(user);
            await _linkedInDbContext.SaveChangesAsync();
            return true;
        }
    }
}
