using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IGlobalConstantsReadCommands
    {
        Task<List<GennericGlobalConstantDto>> GetJobTypeAsync();
        Task<List<GennericGlobalConstantDto>> GetProfessionalBranchDtos();
        Task<List<GennericGlobalConstantDto>> GetReactionsAsync();
        Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync();
    }
}
