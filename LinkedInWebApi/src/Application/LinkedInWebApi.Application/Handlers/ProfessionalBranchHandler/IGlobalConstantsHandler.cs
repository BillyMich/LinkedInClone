using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IGlobalConstantsHandler
    {
        Task<List<GennericGlobalConstantDto>> GetJobTypeAsync();
        Task<List<GennericGlobalConstantDto>> GetProfessionalBranchAsync();
        Task<List<GennericGlobalConstantDto>> GetReactionsAsync();
        Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync();
    }
}
