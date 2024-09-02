using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using LinkiedInWebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands.Update
{
    public class UserUpdateCommands : IUserUpdateCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;


        public UserUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
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
    }
}
