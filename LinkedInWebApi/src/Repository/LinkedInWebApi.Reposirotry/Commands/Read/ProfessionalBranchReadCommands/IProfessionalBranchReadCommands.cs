using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IProfessionalBranchReadCommands
    {

        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();
    }
}
