using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class ContactRequestInsertCommands : IContactRequestInsertCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public ContactRequestInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> CreateContactRequest(NewContactRequestDto ContactRequestDto, int userId)
        {

            try
            {
                await _linkedInDbContext.ContactRequests.AddAsync(ContactRequestDto.ToNewContanctRequest(userId));
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
