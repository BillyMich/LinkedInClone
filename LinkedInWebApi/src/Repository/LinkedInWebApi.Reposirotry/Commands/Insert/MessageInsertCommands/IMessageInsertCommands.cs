using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IMessageInsertCommands
    {
        Task<bool> InsertMessage(NewMessageDto newMessage, int userId);
    }
}
