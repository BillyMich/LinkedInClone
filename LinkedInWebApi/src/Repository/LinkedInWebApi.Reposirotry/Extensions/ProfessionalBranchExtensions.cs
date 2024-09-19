using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class ProfessionalBranchExtensions
    {

        #region RfdtProfessionalBranch

        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtProfessionalBranch professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtProfessionalBranch> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        #endregion

        #region RfdtEducationType
        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtEducationType professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtEducationType> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        #endregion

        #region RfdtJobType

        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtJobType> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtJobType professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }
        #endregion

        #region RfdtReaction

        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtReaction> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtReaction professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        #endregion

        #region RfdtWorkingLocation

        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtWorkingLocation> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtWorkingLocation professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        #endregion

    }
}
