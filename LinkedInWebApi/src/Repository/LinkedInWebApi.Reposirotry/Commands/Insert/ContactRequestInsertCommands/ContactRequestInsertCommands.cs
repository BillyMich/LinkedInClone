using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// Represents the command class for creating a contact request.
    /// </summary>
    public class ContactRequestInsertCommands : IContactRequestInsertCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRequestInsertCommands"/> class.
        /// </summary>
        /// <param name="linkedInDbContext">The LinkedIn database context.</param>
        public ContactRequestInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Creates a new contact request.
        /// </summary>
        /// <param name="contactRequestDto">The contact request DTO.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>A boolean indicating whether the contact request was created successfully.</returns>
        public async Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, int userId)
        {
            try
            {
                await _linkedInDbContext.ContactRequests.AddAsync(contactRequestDto.ToNewContanctRequest(userId));
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
