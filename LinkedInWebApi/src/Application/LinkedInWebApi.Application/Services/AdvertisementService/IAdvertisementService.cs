using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services
{
    public interface IAdvertisementService
    {
        Task<int> CreateAdvertisment(AdvertisementDto advertisementDto);

        Task<bool> UpdateAdvertisment(AdvertisementDto advertisementDto);

        Task<bool> DeleteAdvertisment(int id);

        Task<AdvertisementDto?> GetAdvertisment(int id);

        Task<List<AdvertisementDto>> GetAdvertisments();

        Task<List<AdvertisementDto>> GetAdvertismentsByCreator(int creatorId);

        Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches);

        Task<List<AdvertisementDto>> GetAdvertismentsByStatus(byte status);
    }
}
