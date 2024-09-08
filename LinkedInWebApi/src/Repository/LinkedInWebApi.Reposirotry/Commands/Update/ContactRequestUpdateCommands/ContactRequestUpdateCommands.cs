
using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class ContactRequestUpdateCommands : IContactRequestUpdateCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        public ContactRequestUpdateCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, int userId)
        {

            var contactRequest = await _linkedInDbContext.ContactRequests.FirstOrDefaultAsync(x =>
            x.Id == contactRequestChangeStatusDto.ConctactRequestId && x.UserResiverId == userId);

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
