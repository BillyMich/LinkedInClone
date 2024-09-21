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

        public async Task<bool> UploadNewCVAsync(FileDto fileDto, int userId)
        {
            try
            {
                var userCVs = linkedInDbContext.UserCvs
                    .Where(cv => cv.UserId == userId && cv.IsActive)
                    .ToList();

                // Set IsActive to false for each of them
                foreach (var photo in userCVs)
                {
                    photo.IsActive = false;
                }

                linkedInDbContext.UserCvs.UpdateRange(userCVs);
                await linkedInDbContext.AddAsync(fileDto.ToUserCV(userId));
                await linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UploadNewProfilePictureAsync(FileDto fileDto, int userId)
        {
            try
            {

                // Retrieve all UserPhotoProfiles for the specified userId
                var userPhotoProfiles = linkedInDbContext.UserPhotoProfiles
                    .Where(photo => photo.UserId == userId && photo.IsActive)
                    .ToList();

                // Set IsActive to false for each of them
                foreach (var photo in userPhotoProfiles)
                {
                    photo.IsActive = false;
                }

                // Save changes to the database
                linkedInDbContext.UserPhotoProfiles.UpdateRange(userPhotoProfiles);
                await linkedInDbContext.SaveChangesAsync();

                // Add the new profile picture
                var file = fileDto.ToUserPhotoProfile(userId);
                await linkedInDbContext.UserPhotoProfiles.AddAsync(file);
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
