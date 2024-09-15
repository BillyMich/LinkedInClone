using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    /// <summary>
    /// Represents a handler for professional branches.
    /// </summary>
    public class ProfessionalBranchHandler : IProfessionalBranchHandler
    {
        private readonly IProfessionalBranchService _professionalBranchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionalBranchHandler"/> class.
        /// </summary>
        /// <param name="professionalBranchService">The professional branch service.</param>
        public ProfessionalBranchHandler(IProfessionalBranchService professionalBranchService)
        {
            _professionalBranchService = professionalBranchService;
        }

        /// <summary>
        /// Gets the professional branch DTOs.
        /// </summary>
        /// <returns>The list of professional branch DTOs.</returns>
        public Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos()
        {
            return _professionalBranchService.GetProfessionalBranchDtos();
        }
    }
}
