using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services
{
    public interface IProfessionalBranchService
    {

        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();
    }
}
