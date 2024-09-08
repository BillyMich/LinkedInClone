using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementUpdateCommands
    {
        Task<bool> UpdateAdvertisement(AdvertisementDto advertisementDto, int creatorId);

        Task<bool> DeleteAdvertisement(int id, int userId);
    }
}
