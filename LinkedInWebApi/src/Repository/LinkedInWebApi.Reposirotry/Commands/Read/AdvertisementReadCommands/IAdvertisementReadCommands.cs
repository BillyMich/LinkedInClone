using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementReadCommands
    {
        Task<List<UserDto>> ApplyApplicantAsync(int id);
        Task<AdvertisementDto?> GetAdvertisment(int id);
        Task<List<AdvertisementDto>?> GetAdvertisments();
        Task<List<AdvertisementDto>?> GetAdvertismentsByCreator(int creatorId);
        Task<List<AdvertisementDto>?> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches);
        Task<List<AdvertisementDto>?> GetAdvertisementsByStatus(byte status);
        Task<List<AdvertisementDto>?> GetMyAdvertisements(int curentUserId);
    }
}
