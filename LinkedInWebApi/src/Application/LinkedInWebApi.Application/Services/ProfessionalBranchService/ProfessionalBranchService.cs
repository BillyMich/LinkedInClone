using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    /// <summary>
    /// Service class for handling professional branches.
    /// </summary>
    public class ProfessionalBranchService : IProfessionalBranchService
    {
        private readonly IProfessionalBranchReadCommands _professionalBranchReadCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionalBranchService"/> class.
        /// </summary>
        /// <param name="professionalBranchReadCommands">The professional branch read commands.</param>
        public ProfessionalBranchService(IProfessionalBranchReadCommands professionalBranchReadCommands)
        {
            _professionalBranchReadCommands = professionalBranchReadCommands;
        }

        /// <summary>
        /// Retrieves a list of professional branch DTOs.
        /// </summary>
        /// <returns>The list of professional branch DTOs.</returns>
        public async Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos()
        {
            return await _professionalBranchReadCommands.GetProfessionalBranchDtos();
        }
    }
}
