using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestReadCommands
    {

        Task<List<UserDto>> GetConnectedUsersAsync(int userId);

        Task<List<ContactRequestDto>> GetPendingConnectContactsAsync(int userId);
    }
}
