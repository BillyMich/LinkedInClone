using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IAdvertisementInserCommands
    {
        Task<bool> ApplyForAdvertismentAsync(int applyForAdvertismentDto, int userId);
        Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, int userId);

    }
}
