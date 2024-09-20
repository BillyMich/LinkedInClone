using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    /// <summary>
    /// Represents a handler for professional branches.
    /// </summary>
    public class GlobalConstantsHandler : IGlobalConstantsHandler
    {
        private readonly IGlobalConstantsServices _globalConstantsServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstantsHandler"/> class.
        /// </summary>
        /// <param name="globalConstantsServices">The professional branch service.</param>
        public GlobalConstantsHandler(IGlobalConstantsServices globalConstantsServices)
        {
            _globalConstantsServices = globalConstantsServices;
        }

        /// <summary>
        /// Gets the job types.
        /// </summary>
        /// <returns>The list of job types.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetJobTypeAsync()
        {
            return await _globalConstantsServices.GetJobTypeAsync();
        }

        /// <summary>
        /// Gets the professional branch DTOs.
        /// </summary>
        /// <returns>The list of professional branch DTOs.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetProfessionalBranchAsync()
        {
            return await _globalConstantsServices.GetProfessionalBranchDtos();
        }

        /// <summary>
        /// Gets the reactions.
        /// </summary>
        /// <returns>The list of reactions.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetReactionsAsync()
        {
            return await _globalConstantsServices.GetReactionsAsync();
        }

        /// <summary>
        /// Gets the working locations.
        /// </summary>
        /// <returns>The list of working locations.</returns>
        public async Task<List<GennericGlobalConstantDto>> GetWorkingLocationsAsync()
        {
            return await _globalConstantsServices.GetWorkingLocationsAsync();
        }
    }
}
