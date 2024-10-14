using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// Represents the commands for reading global constants.
    /// </summary>
    public class GlobalConstantsReadCommands : IGlobalConstantsReadCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstantsReadCommands"/> class.
        /// </summary>
        /// <param name="linkedInDbContext">The LinkedIn database context.</param>
        public GlobalConstantsReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Gets the job types.
        /// </summary>
        /// <returns>A list of job types.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetJobTypeAsync()
        {
            try
            {
                var gennericGlobalConstant = await _linkedInDbContext.RfdtJobTypes.ToListAsync();
                return gennericGlobalConstant.ToGennericGlobalConstantDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the professional branch DTOs.
        /// </summary>
        /// <returns>A list of professional branch DTOs.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetProfessionalBranchDtos()
        {
            try
            {
                var gennericGlobalConstant = await _linkedInDbContext.RfdtProfessionalBranches.ToListAsync();
                return gennericGlobalConstant.ToGennericGlobalConstantDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the working locations.
        /// </summary>
        /// <returns>A list of working locations.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync()
        {
            try
            {
                var gennericGlobalConstant = await _linkedInDbContext.RfdtWorkingLocations.ToListAsync();
                return gennericGlobalConstant.ToGennericGlobalConstantDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
