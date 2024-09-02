using LinkedInWebApi.Core.Dto;
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


        public async Task<bool> CreateAdvertisement(AdvertisementDto advertisementDto)
        {
            try
            {
                await _linkedInDbContext.Advertisements.AddAsync(advertisementDto.ToAdvertisement());
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
