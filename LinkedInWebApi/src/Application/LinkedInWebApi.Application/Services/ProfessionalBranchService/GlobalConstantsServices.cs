using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    /// <summary>
    /// Service class for handling professional branches.
    /// </summary>
    public class GlobalConstantsServices : IGlobalConstantsServices
    {
        private readonly IGlobalConstantsReadCommands _globalConstantsReadCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstantsServices"/> class.
        /// </summary>
        /// <param name="globalConstantsReadCommands">The professional branch read commands.</param>
        public GlobalConstantsServices(IGlobalConstantsReadCommands globalConstantsReadCommands)
        {
            _globalConstantsReadCommands = globalConstantsReadCommands;
        }

        /// <summary>
        /// Retrieves a list of job types.
        /// </summary>
        /// <returns>The list of job types.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetJobTypeAsync()
        {
            return await _globalConstantsReadCommands.GetJobTypeAsync();
        }

        /// <summary>
        /// Retrieves a list of professional branch DTOs.
        /// </summary>
        /// <returns>The list of professional branch DTOs.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetProfessionalBranchDtos()
        {
            return await _globalConstantsReadCommands.GetProfessionalBranchDtos();
        }

        /// <summary>
        /// Retrieves a list of working locations.
        /// </summary>
        /// <returns>The list of working locations.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync()
        {
            return await _globalConstantsReadCommands.GetWorkingLocationsAsync();
        }
    }
}
