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
        private readonly IUserReadCommands _userReadCommands;

        public ContactRequestService(IContactRequestInsertCommands contactRequestInsertCommands, IContactRequestUpdateCommands contactRequestUpdateCommands, IContactRequestReadCommands contactRequestReadCommands, IUserReadCommands userReadCommands)
        {
            _contactRequestInsertCommands = contactRequestInsertCommands;
            _contactRequestUpdateCommands = contactRequestUpdateCommands;
            _contactRequestReadCommands = contactRequestReadCommands;
            _userReadCommands = userReadCommands;
        }

        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);
            var result = await _contactRequestUpdateCommands.ChangeStatusOfRequest(contactRequestChangeStatusDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        public async Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var result = await _contactRequestInsertCommands.CreateContactRequest(contactRequestDto, curentUserId);

            return result;

        }

        public Task<List<ContactRequestDto>> GetPendingConnectContactsAsync(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return _contactRequestReadCommands.GetPendingConnectContactsAsync(curentUserId);
        }

        public Task<List<UserDto>> GetConnectedUsersAsync(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return _contactRequestReadCommands.GetConnectedUsersAsync(curentUserId);
        }

        public async Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return await GetNonConnectedUsers(curentUserId);
        }

        internal async Task<List<UserDto>> GetNonConnectedUsers(int curentUserId)
        {
            var connectedUsers = await _contactRequestReadCommands.GetConnectedUsersAsync(curentUserId);
            var allUsers = await _userReadCommands.GetUsersAsync(null);
            var nonConnectedUsers = allUsers.Except(connectedUsers).ToList();

            return nonConnectedUsers;
        }
    }
}
