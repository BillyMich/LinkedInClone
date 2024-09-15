using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IProfessionalBranchHandler
    {
        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();

    }
}
