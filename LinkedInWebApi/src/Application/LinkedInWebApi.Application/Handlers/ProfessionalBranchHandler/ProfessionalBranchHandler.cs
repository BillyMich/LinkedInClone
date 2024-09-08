using LinkedInWebApi.Core.Dto;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public class ProfessionalBranchHandler : IProfessionalBranchHandler
    {
        public Task<int> CreateProfessionalBranch(ProfessionalBranchDto professionalBranchDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProfessionalBranch(int id, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<ProfessionalBranchDto?> GetProfessionalBranchDto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProfessionalBranch(ProfessionalBranchDto professionalBranchDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
