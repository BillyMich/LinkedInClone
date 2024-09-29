using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class AdvertisementInserCommands : IAdvertisementInserCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public AdvertisementInserCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> ApplyForAdvertismentAsync(int applyForAdvertismentDto, int userId)
        {
            try
            {
                _linkedInDbContext.AdvertisementApplies.Add(applyForAdvertismentDto.ToAdvertisementApply(userId));
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, int userId)
        {
            try
            {
                await _linkedInDbContext.Advertisements.AddAsync(advertisementDto.ToAdvertisement(userId));
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
