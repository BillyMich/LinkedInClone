using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IContactRequestHandler
    {

        Task CreateContactRequest(ContactRequestDto contactRequestDto);

        Task AcceptContactRequest(int userId, int contactRequestId);

        Task<List<ContactRequestDto>> GetContacts(int userId);

        Task<List<ContactRequestDto>> GetContactRequests(int userId);
    }
}
