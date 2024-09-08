using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestReadCommands
    {

        Task<List<UserDto>> GetConnectedUsers(int userId);

        Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId);
    }
}
