using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IAdvertisementHandler
    {

        Task<bool> CreateAdvertisementAsync(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity);

        Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity);

        Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity);

        Task<AdvertisementDto?> GetAdvertismentAsync(int id, ClaimsIdentity claimsIdentity);

        Task<List<AdvertisementDto>> GetAdvertismentsAsync(ClaimsIdentity claimsIdentity);

        Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranchesAsync(List<int> professionalBranches);

        Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity);
        Task<List<AdvertisementDto>> GetMyAdvertisementAsync(ClaimsIdentity identity);
    }
}
