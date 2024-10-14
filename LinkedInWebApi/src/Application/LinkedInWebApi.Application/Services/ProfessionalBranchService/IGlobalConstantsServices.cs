using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services
{
    public interface IGlobalConstantsServices
    {
        Task<List<GennericGlobalConstantDto>> GetJobTypeAsync();
        Task<List<GennericGlobalConstantDto>> GetProfessionalBranchDtos();
        Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync();
    }
}
