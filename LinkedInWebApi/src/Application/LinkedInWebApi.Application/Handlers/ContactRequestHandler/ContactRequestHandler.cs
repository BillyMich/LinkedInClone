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

        public async Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.CreateContactRequest(contactRequestDto, claimsIdentity);
        }

        public async Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int statusId, ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetConnectedContactsByStatus(statusId, claimsIdentity);
        }

        public async Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity)
        {
            return await _contactRequestService.GetConnectedUsers(claimsIdentity);
        }
    }
}
