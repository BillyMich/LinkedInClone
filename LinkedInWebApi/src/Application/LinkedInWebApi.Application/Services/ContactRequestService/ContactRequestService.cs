using LinkedInWebApi.Core;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class ContactRequestService : IContactRequestService
    {
        private readonly IContactRequestInsertCommands _contactRequestInsertCommands;
        private readonly IContactRequestUpdateCommands _contactRequestUpdateCommands;
        private readonly IContactRequestReadCommands _contactRequestReadCommands;


        public ContactRequestService(IContactRequestInsertCommands contactRequestInsertCommands, IContactRequestUpdateCommands contactRequestUpdateCommands, IContactRequestReadCommands contactRequestReadCommands)
        {
            _contactRequestInsertCommands = contactRequestInsertCommands;
            _contactRequestUpdateCommands = contactRequestUpdateCommands;
            _contactRequestReadCommands = contactRequestReadCommands;
        }

        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);
            var result = await _contactRequestUpdateCommands.ChangeStatusOfRequest(contactRequestChangeStatusDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        public async Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            var result = await _contactRequestInsertCommands.CreateContactRequest(contactRequestDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        public Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int statusId, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            return _contactRequestReadCommands.GetConnectedContactsByStatus(curentUserId);
        }

        public Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            return _contactRequestReadCommands.GetConnectedUsers(curentUserId);
        }
    }
}
