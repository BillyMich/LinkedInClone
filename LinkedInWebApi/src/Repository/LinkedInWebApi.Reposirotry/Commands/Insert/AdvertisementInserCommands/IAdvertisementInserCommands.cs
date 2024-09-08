using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementInserCommands
    {

        Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, int userId);

    }
}
