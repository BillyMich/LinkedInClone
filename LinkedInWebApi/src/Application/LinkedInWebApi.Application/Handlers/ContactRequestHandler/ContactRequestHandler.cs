using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    /// <summary>
    /// Handles contact requests and interacts with the contact request service.
    /// </summary>
    public class ContactRequestHandler : IContactRequestHandler
    {
        private readonly IContactRequestService _contactRequestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRequestHandler"/> class.
        /// </summary>
        /// <param name="contactRequestService">The contact request service.</param>
        public ContactRequestHandler(IContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

        /// <summary>
        /// Changes the status of a contact request.
        /// </summary>
        /// <param name="contactRequestChangeStatusDto">The contact request change status DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        public async Task ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity)
        {
            await _contactRequestService.ChangeStatusOfRequest(contactRequestChangeStatusDto, claimsIdentity);
        }

        /// <summary>
        /// Creates a new contact request.
        /// </summary>
        /// <param name="contactRequestDto">The new contact request DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>True if the contact request is created successfully, otherwise false.</returns>
        public async Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.CreateContactRequest(contactRequestDto, claimsIdentity);
        }

        /// <summary>
        /// Gets the pending connect contacts for a user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>The contact request of user DTO.</returns>
        public async Task<ContactRequestOfUserDto> GetPendingConnectContacts(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetPendingConnectContactsAsync(claimsIdentity);
        }

        /// <summary>
        /// Gets the connected users for a user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A list of connected user DTOs.</returns>
        public async Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetConnectedUsersAsync(claimsIdentity);
        }

        /// <summary>
        /// Gets the non-connected users for a user.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A list of non-connected user DTOs.</returns>
        public async Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetNonConnectedUsers(claimsIdentity);
        }
    }
}
