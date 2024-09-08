using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public class ContactRequestHandler : IContactRequestHandler
    {
        private readonly IContactRequestService _contactRequestService;

        public ContactRequestHandler(IContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

        public async Task<bool> ChangeStatusOfRequest(int requestId, bool status)
        {
            return await _contactRequestService.ChangeStatusOfRequest(requestId, status);
        }

        public async Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto)
        {
            return await _contactRequestService.CreateContactRequest(contactRequestDto);
        }

        public async Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId, int statusId)
        {
            return await _contactRequestService.GetConnectedContactsByStatus(userId, statusId);
        }

        public async Task<List<UserDto>> GetConnectedUsers(int userId)
        {
            return await _contactRequestService.GetConnectedUsers(userId);
        }
    }
}
