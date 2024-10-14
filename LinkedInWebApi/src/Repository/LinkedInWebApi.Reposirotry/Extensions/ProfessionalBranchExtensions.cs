using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    /// <summary>
    /// Extension methods for converting professional branch entities to generic global constant DTOs.
    /// </summary>
    public static class ProfessionalBranchExtensions
    {
        #region RfdtProfessionalBranch

        /// <summary>
        /// Converts a single RfdtProfessionalBranch entity to a GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranch">The RfdtProfessionalBranch entity to convert.</param>
        /// <returns>The converted GennericGlobalConstantDto.</returns>
        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtProfessionalBranch professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        /// <summary>
        /// Converts a list of RfdtProfessionalBranch entities to a list of GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranches">The list of RfdtProfessionalBranch entities to convert.</param>
        /// <returns>The converted list of GennericGlobalConstantDto.</returns>
        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtProfessionalBranch> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        #endregion

        #region RfdtEducationType

        /// <summary>
        /// Converts a single RfdtEducationType entity to a GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranch">The RfdtEducationType entity to convert.</param>
        /// <returns>The converted GennericGlobalConstantDto.</returns>
        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtEducationType professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        /// <summary>
        /// Converts a list of RfdtEducationType entities to a list of GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranches">The list of RfdtEducationType entities to convert.</param>
        /// <returns>The converted list of GennericGlobalConstantDto.</returns>
        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtEducationType> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        #endregion

        #region RfdtJobType

        /// <summary>
        /// Converts a list of RfdtJobType entities to a list of GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranches">The list of RfdtJobType entities to convert.</param>
        /// <returns>The converted list of GennericGlobalConstantDto.</returns>
        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtJobType> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        /// <summary>
        /// Converts a single RfdtJobType entity to a GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranch">The RfdtJobType entity to convert.</param>
        /// <returns>The converted GennericGlobalConstantDto.</returns>
        public static GennericGlobalConstantDto ToGennericGlobalConstantDto(this RfdtJobType professionalBranch)
        {
            return new GennericGlobalConstantDto
            {
                Id = professionalBranch.Id,
                Name = professionalBranch.Name,
            };
        }

        #endregion

        #region RfdtWorkingLocation

        /// <summary>
        /// Converts a list of RfdtWorkingLocation entities to a list of GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranches">The list of RfdtWorkingLocation entities to convert.</param>
        /// <returns>The converted list of GennericGlobalConstantDto.</returns>
        public static List<GennericGlobalConstantDto> ToGennericGlobalConstantDto(this List<RfdtWorkingLocation> professionalBranches)
        {
            return professionalBranches.Select(professionalBranch => professionalBranch.ToGennericGlobalConstantDto()).ToList();
        }

        /// <summary>
        /// Converts a single RfdtWorkingLocation entity to a GennericGlobalConstantDto.
        /// </summary>
        /// <param name="professionalBranch">The RfdtWorkingLocation entity to convert.</param>
        /// <returns>The converted GennericGlobalConstantDto.</returns>
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
