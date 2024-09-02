using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public class ContactRequestHandler : IContactRequestHandler
    {
        public Task AcceptContactRequest(int userId, int contactRequestId)
        {
            throw new NotImplementedException();
        }

        public Task CreateContactRequest(ContactRequestDto contactRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactRequestDto>> GetContactRequests(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactRequestDto>> GetContacts(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
