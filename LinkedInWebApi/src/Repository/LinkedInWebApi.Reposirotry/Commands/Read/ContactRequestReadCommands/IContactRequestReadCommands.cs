using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestReadCommands
    {
        Task<bool> CheckIfExistAlreadyAsync(NewContactRequestDto contactRequestDto, int curentUserId);
        Task<List<UserDto>> GetConnectedUsersAsync(int userId);

        Task<List<ContactRequestDto>> GetPendingConnectContactsAsync(int userId);
    }
}
