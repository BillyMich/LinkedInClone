using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisemenReadCommands
    {
        Task<List<UserDto>> ApplyApplicantAsync(int id);
        Task<AdvertisementDto?> GetAdvertisment(int id);

        Task<List<AdvertisementDto>> GetAdvertisments();

        Task<List<AdvertisementDto>> GetAdvertismentsByCreator(int creatorId);

        Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches);

        Task<List<AdvertisementDto>> GetAdvertismentsByStatus(byte status);
        Task<List<AdvertisementDto>> GetMyAdvertisments(int curentUserId);
    }
}
