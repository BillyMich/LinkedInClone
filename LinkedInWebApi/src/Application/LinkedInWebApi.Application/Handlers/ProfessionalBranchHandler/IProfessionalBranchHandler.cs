using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IProfessionalBranchHandler
    {
        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();
    }
}
