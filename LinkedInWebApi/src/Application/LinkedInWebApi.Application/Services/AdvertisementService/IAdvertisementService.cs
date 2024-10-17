using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IAdvertisementService
    {
        Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity);
        Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity);
        Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity);
        Task<AdvertisementDto?> GetAdvertisment(int id, ClaimsIdentity claimsIdentity);
        Task<List<AdvertisementDto>?> GetAdvertisments(ClaimsIdentity claimsIdentity);
        Task<List<AdvertisementDto>?> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches);
        Task<List<AdvertisementDto>?> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity);
        Task<List<AdvertisementDto>?> GetMyAdvertisementAsync(ClaimsIdentity identity);
        Task<bool> ApplyForAdvertismentAsync(int applyForAdvertismentDto, ClaimsIdentity identity);
        Task<List<UserDto>?> ApplyApplicantAsync(int id, ClaimsIdentity identity);
        Task<List<ApplicationNotificationDto>?> GetApplyApplicationNotificationAsync(ClaimsIdentity identity);
    }
}
