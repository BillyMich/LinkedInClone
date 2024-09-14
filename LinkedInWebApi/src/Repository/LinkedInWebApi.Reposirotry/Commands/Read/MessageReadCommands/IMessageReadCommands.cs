using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IMessageReadCommands
    {

        Task<List<ChatDto>?> GetChatsOfUserAsync(int userId);

        Task<List<MessageDto>?> GetMessagesOfChatAsync(int? chatId);

        Task<int?> GetChatIdAsync(int userId, int otherUserId);

    }
}
