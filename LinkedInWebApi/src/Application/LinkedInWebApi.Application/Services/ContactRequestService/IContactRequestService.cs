using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IContactRequestService
    {
        Task<List<UserDto>> GetConnectedUsers(ClaimsIdentity claimsIdentity);

        Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int statusId, ClaimsIdentity claimsIdentity);

        Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto, ClaimsIdentity claimsIdentity);

        Task<bool> ChangeStatusOfRequest(ContactRequestChangeStatusDto contactRequestChangeStatusDto, ClaimsIdentity claimsIdentity);
    }
}
