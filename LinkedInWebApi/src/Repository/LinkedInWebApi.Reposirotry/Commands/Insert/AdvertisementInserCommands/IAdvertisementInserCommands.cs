using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    internal interface IAdvertisementInserCommands
    {

        Task<bool> CreateAdvertisement(AdvertisementDto advertisementDto);

    }
}
