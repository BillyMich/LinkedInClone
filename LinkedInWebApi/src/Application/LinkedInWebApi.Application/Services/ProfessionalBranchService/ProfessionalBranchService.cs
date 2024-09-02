using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    public class ProfessionalBranchService : IProfessionalBranchService
    {

        private readonly IProfessionalBranchReadCommands _professionalBranchReadCommands;

        public ProfessionalBranchService(IProfessionalBranchReadCommands professionalBranchReadCommands)
        {
            _professionalBranchReadCommands = professionalBranchReadCommands;
        }

        public async Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos()
        {
            return await _professionalBranchReadCommands.GetProfessionalBranchDtos();
        }
    }
}
