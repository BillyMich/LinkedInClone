using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// Represents the commands for reading professional branches.
    /// </summary>
    public class ProfessionalBranchReadCommands : IProfessionalBranchReadCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionalBranchReadCommands"/> class.
        /// </summary>
        /// <param name="linkedInDbContext">The LinkedIn database context.</param>
        public ProfessionalBranchReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Gets the professional branch DTOs.
        /// </summary>
        /// <returns>A list of professional branch DTOs.</returns>
        public async Task<List<ProfessionalBranchDto>> GetProfessionalBranchDtos()
        {
            try
            {
                var professionalBranches = await _linkedInDbContext.ProfessionalBranches.ToListAsync();
                return professionalBranches.ToProfessionalBranchDtos();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
