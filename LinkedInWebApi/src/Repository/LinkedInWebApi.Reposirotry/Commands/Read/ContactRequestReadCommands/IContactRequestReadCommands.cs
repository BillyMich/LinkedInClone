using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestReadCommands
    {

        Task<List<UserDto>> GetConnectedUsers(int userId);

        Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId, int statusId);
    }
}
