using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public class AdvertisementHandler : IAdvertisementHandler
    {
        public Task<int> CreateAdvertisment(AdvertisementDto advertisementDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAdvertisment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisementDto?> GetAdvertisment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementDto>> GetAdvertisments()
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByCreator(int creatorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByStatus(byte status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdvertisment(AdvertisementDto advertisementDto)
        {
            throw new NotImplementedException();
        }
    }
}
