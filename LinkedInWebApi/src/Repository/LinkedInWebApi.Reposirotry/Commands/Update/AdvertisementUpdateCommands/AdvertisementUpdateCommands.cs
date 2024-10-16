using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class AdvertisementUpdateCommands : IAdvertisementUpdateCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public AdvertisementUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> DeleteAdvertisement(int id, int creatorId)
        {
            try
            {
                var advertisement = await _linkedInDbContext.Advertisements.FirstOrDefaultAsync(x => x.Id == id && x.CreatorId == creatorId);

                if (advertisement == null)
                {
                    return false;
                }

                _linkedInDbContext.Advertisements.Remove(advertisement);
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAdvertisementAsync(UpdateAdvertisementDto advertisementDto, int creatorId)
        {

            try
            {
                var advertisement = await _linkedInDbContext.Advertisements.FirstOrDefaultAsync(x => x.Id == advertisementDto.Id && x.CreatorId == creatorId);

                if (advertisement == null)
                {
                    return false;
                }

                advertisement.ToUpdateAdvertisement(advertisementDto);
                _linkedInDbContext.Advertisements.Update(advertisement);
                _linkedInDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
