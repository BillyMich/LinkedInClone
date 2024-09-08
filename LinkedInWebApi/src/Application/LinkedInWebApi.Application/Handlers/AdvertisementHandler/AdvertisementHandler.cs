using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public class AdvertisementHandler : IAdvertisementHandler
    {

        private readonly IAdvertisementService _advertisementService;

        public AdvertisementHandler(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.CreateAdvertisement(advertisementDto, claimsIdentity);
        }

        public Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.DeleteAdvertisment(id, claimsIdentity);
        }

        public Task<AdvertisementDto?> GetAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisment(id, claimsIdentity);
        }

        public Task<List<AdvertisementDto>> GetAdvertisments(ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisments(claimsIdentity);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            return _advertisementService.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatus(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertismentsOfUserByStatus(status, claimsIdentity);
        }

        public Task<bool> UpdateAdvertisment(AdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.UpdateAdvertisment(advertisementDto, claimsIdentity);
        }
    }
}
