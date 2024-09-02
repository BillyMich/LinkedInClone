using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class ProfessionalBranchExtensions
    {

        public static ProfessionalBranchDto ToProfessionalBranchDto(this ProfessionalBranch professionalBranch)
        {
            return new ProfessionalBranchDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        public static List<ProfessionalBranchDto> ToProfessionalBranchDtos(this List<ProfessionalBranch> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToProfessionalBranchDto()).ToList();
        }
    }
}
