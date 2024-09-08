using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IProfessionalBranchHandler
    {
        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();

        Task<ProfessionalBranchDto?> GetProfessionalBranchDto(int id);

        Task<int> CreateProfessionalBranch(ProfessionalBranchDto professionalBranchDto, ClaimsIdentity claimsIdentity);

        Task<bool> UpdateProfessionalBranch(ProfessionalBranchDto professionalBranchDto, ClaimsIdentity claimsIdentity);

        Task<bool> DeleteProfessionalBranch(int id, ClaimsIdentity claimsIdentity);
    }
}
