using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IContactRequestHandler
    {

        Task<List<UserDto>> GetConnectedUsers(int userId);

        Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId, int statusId);

        Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto);

        Task<bool> ChangeStatusOfRequest(int requestId, bool status);
    }
}
