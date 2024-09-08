using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Services
{
    public interface IContactRequestService
    {
        Task<List<UserDto>> GetConnectedUsers(int userId);

        Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId, int statusId);

        Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto);

        Task<bool> ChangeStatusOfRequest(int requestId, bool status);
    }
}
