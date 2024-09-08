using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services
{
    public interface IProfessionalBranchService
    {

        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();
    }
}
