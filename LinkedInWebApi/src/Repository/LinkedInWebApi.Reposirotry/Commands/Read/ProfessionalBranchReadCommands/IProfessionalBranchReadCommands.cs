using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IProfessionalBranchReadCommands
    {

        Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos();
    }
}
