using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IContactRequestHandler
    {

        Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity);

        Task<List<UserDto>> GetNonConnectedUsers(ClaimsIdentity claimsIdentity);

        Task<List<ContactRequestDto>> GetPendingConnectContacts(ClaimsIdentity claimsIdentity);

        Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity);

        Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity);
    }
}
