using LinkedInWebApi.Core;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    /// <summary>
    /// Service class for managing contact requests.
    /// </summary>
    public class ContactRequestService : IContactRequestService
    {
        private readonly IContactRequestInsertCommands _contactRequestInsertCommands;
        private readonly IContactRequestUpdateCommands _contactRequestUpdateCommands;
        private readonly IContactRequestReadCommands _contactRequestReadCommands;
        private readonly IUserReadCommands _userReadCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRequestService"/> class.
        /// </summary>
        /// <param name="contactRequestInsertCommands">The contact request insert commands.</param>
        /// <param name="contactRequestUpdateCommands">The contact request update commands.</param>
        /// <param name="contactRequestReadCommands">The contact request read commands.</param>
        /// <param name="userReadCommands">The user read commands.</param>
        public ContactRequestService(IContactRequestInsertCommands contactRequestInsertCommands, IContactRequestUpdateCommands contactRequestUpdateCommands, IContactRequestReadCommands contactRequestReadCommands, IUserReadCommands userReadCommands)
        {
            _contactRequestInsertCommands = contactRequestInsertCommands;
            _contactRequestUpdateCommands = contactRequestUpdateCommands;
            _contactRequestReadCommands = contactRequestReadCommands;
            _userReadCommands = userReadCommands;
        }

        /// <summary>
        /// Changes the status of a contact request.
        /// </summary>
        /// <param name="contactRequestChangeStatusDto">The contact request change status DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity)
        {
            var result = await _contactRequestUpdateCommands.ChangeStatusOfRequest(contactRequestChangeStatusDto, ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        /// <summary>
        /// Creates a new contact request.
        /// </summary>
        /// <param name="contactRequestDto">The contact request DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var checkIfExistAlready = await _contactRequestReadCommands.CheckIfExistAlreadyAsync(contactRequestDto, ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));

            if (checkIfExistAlready)
            {
                throw ErrorException.ContactRequestAlreadyExistException;
            }

            var result = await _contactRequestInsertCommands.CreateContactRequest(contactRequestDto, curentUserId);

            return result;
        }

        /// <summary>
        /// Gets the pending connect contacts for the current user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<ContactRequestOfUserDto> GetPendingConnectContactsAsync(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var connectionRequestOfUser = await _contactRequestReadCommands.GetPendingConnectContactsAsync(ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));

            return FilterContanctRequest(connectionRequestOfUser, curentUserId);
        }

        /// <summary>
        /// Gets the connected users for the current user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<UserDto>> GetConnectedUsersAsync(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestReadCommands.GetConnectedUsersAsync(ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));
        }

        /// <summary>
        /// Gets the non-connected users for the current user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return await GetNonConnectedUsers(curentUserId);
        }

        /// <summary>
        /// Gets the non-connected users for the specified user ID.
        /// </summary>
        /// <param name="curentUserId">The current user ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        internal async Task<List<UserDto>> GetNonConnectedUsers(int curentUserId)
        {
            var connectedUsers = await _contactRequestReadCommands.GetConnectedUsersAsync(curentUserId);
            var allUsers = await _userReadCommands.GetUsersAsync(null);
            var nonConnectedUsers = allUsers.Except(connectedUsers).ToList();
            nonConnectedUsers.RemoveAll(x => x.Id == curentUserId);
            return nonConnectedUsers;
        }

        /// <summary>
        /// Filters the contact requests based on the current user ID.
        /// </summary>
        /// <param name="contactRequestDtos">The contact request DTOs.</param>
        /// <param name="curentUserId">The current user ID.</param>
        /// <returns>The filtered contact requests.</returns>
        internal ContactRequestOfUserDto FilterContanctRequest(List<ContactRequestDto> contactRequestDtos, int curentUserId)
        {
            var contactRequestOfUserDto = new ContactRequestOfUserDto()
            {
                ContactRequestsFrom = contactRequestDtos.Where(x => x.UserResiverId != curentUserId).ToList(),
                ContactRequestsTo = contactRequestDtos.Where(x => x.UserResiverId == curentUserId).ToList(),
            };
            return contactRequestOfUserDto;
        }
    }
}
