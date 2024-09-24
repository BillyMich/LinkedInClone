using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserInsertCommands
    {
        Task<bool> InsertUserEducationAsync(CreateUserEducation createUserEducation, int curentUserId);
        Task<bool> InsertUserExperienceAsync(CreateUserExperience createUserExperience, int curentUserId);
        Task<bool> RegisterUserAsync(UserDto registerDto);
        Task<bool> UploadNewCVAsync(FileDto fileDto, int curentUserId);
        Task<bool> UploadNewProfilePictureAsync(FileDto fileDto, int userId);

    }
}
