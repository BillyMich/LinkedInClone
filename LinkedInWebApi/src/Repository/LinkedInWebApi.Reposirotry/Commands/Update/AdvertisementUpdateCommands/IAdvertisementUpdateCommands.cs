using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementUpdateCommands
    {
        Task<bool> UpdateAdvertisement(AdvertisementDto advertisementDto);
    }
}
