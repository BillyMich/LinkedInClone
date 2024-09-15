
using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// Represents a class that provides methods to update contact request information.
    /// </summary>
    public class ContactRequestUpdateCommands : IContactRequestUpdateCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRequestUpdateCommands"/> class.
        /// </summary>
        /// <param name="linkedInDbContext">The LinkedIn database context.</param>
        public ContactRequestUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Changes the status of a contact request.
        /// </summary>
        /// <param name="contactRequestChangeStatusDto">The contact request change status DTO.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the status change was successful.</returns>
        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, int userId)
        {
            var contactRequest = await _linkedInDbContext.ContactRequests.FirstOrDefaultAsync(x =>
                x.Id == contactRequestChangeStatusDto.ContactRequestId && x.UserResiverId == userId);

            if (contactRequest == null)
            {
                return false;
            }

            if (contactRequestChangeStatusDto.StatusId == 1)
            {
                contactRequest.IsAccepted = true;
            }
            else
            {
                contactRequest.IsActive = false;
            }

            _linkedInDbContext.ContactRequests.Update(contactRequest);
            await _linkedInDbContext.SaveChangesAsync();
            return true;
        }
    }
}
