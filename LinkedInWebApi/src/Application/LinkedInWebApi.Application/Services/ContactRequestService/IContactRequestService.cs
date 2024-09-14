using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IContactRequestService
    {
        Task<List<UserDto>> GetConnectedUsersAsync(ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity);

        Task<List<ContactRequestDto>> GetPendingConnectContactsAsync(ClaimsIdentity claimsIdentity);

        Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity);

        Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity);
    }
}
