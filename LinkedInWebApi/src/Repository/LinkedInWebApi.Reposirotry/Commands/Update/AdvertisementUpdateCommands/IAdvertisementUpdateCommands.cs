using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementUpdateCommands
    {
        Task<bool> UpdateAdvertisementAsync(UpdateAdvertisementDto advertisementDto, int creatorId);

        Task<bool> DeleteAdvertisement(int id, int userId);
    }
}
