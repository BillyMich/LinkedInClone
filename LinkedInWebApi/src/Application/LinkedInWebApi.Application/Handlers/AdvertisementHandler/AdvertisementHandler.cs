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

        public Task<bool> CreateAdvertisementAsync(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.CreateAdvertisement(advertisementDto, claimsIdentity);
        }

        public Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.DeleteAdvertisment(id, claimsIdentity);
        }

        public Task<AdvertisementDto?> GetAdvertismentAsync(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisment(id, claimsIdentity);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsAsync(ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisments(claimsIdentity);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranchesAsync(List<int> professionalBranches)
        {
            return _advertisementService.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertismentsOfUserByStatusAsync(status, claimsIdentity);
        }

        public Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.UpdateAdvertismentAsync(advertisementDto, claimsIdentity);
        }
    }
}
