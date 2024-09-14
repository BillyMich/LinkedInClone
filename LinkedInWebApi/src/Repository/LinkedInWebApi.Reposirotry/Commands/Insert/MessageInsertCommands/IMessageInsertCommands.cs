using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IMessageInsertCommands
    {
        Task<bool> InsertMessageAsync(NewMessageDto newMessage, int userId, int? chatId);

        Task<int> CreateChatAsync(int userId1, int userId2);
    }
}
