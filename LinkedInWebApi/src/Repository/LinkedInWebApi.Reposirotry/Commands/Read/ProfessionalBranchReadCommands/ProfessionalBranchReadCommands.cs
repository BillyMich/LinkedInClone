using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class ProfessionalBranchReadCommands : IProfessionalBranchReadCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public ProfessionalBranchReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

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
