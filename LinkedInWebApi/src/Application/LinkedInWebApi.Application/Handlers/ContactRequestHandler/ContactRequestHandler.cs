using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public class ContactRequestHandler : IContactRequestHandler
    {
        private readonly IContactRequestService _contactRequestService;

        public ContactRequestHandler(IContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

        public async Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.ChangeStatusOfRequest(contactRequestChangeStatusDto, claimsIdentity);
        }

        public async Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.CreateContactRequest(contactRequestDto, claimsIdentity);
        }

        public async Task<List<ContactRequestDto>> GetPendingConnectContacts(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetPendingConnectContactsAsync(claimsIdentity);
        }

        public async Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetConnectedUsersAsync(claimsIdentity);
        }

        public Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
