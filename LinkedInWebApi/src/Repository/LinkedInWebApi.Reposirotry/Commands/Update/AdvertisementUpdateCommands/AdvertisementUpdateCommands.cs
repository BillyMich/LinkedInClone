using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class AdvertisementUpdateCommands : IAdvertisementUpdateCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public AdvertisementUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public Task<bool> UpdateAdvertisement(AdvertisementDto advertisementDto)
        {

            return null;


        }
    }
}
