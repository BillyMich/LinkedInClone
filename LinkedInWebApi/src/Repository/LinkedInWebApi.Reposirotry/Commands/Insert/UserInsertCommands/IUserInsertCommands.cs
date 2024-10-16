using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IUserInsertCommands
    {
        Task InsertUserEducationAsync(CreateUserEducationDto createUserEducation, int curentUserId);
        Task InsertUserExperienceAsync(CreateUserExperienceDto createUserExperience, int curentUserId);
        Task<bool> RegisterUserAsync(UserDto registerDto);
        Task<bool> UploadNewCVAsync(FileDto fileDto, int curentUserId);
        Task<bool> UploadNewProfilePictureAsync(FileDto fileDto, int userId);

    }
}
