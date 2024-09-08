using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IMessageReadCommands
    {

        Task<List<ChatDto>?> GetChatsOfUser(int userId);

        Task<List<MessageDto>?> GetMessagesOfChat(int chatId);

        Task<int> GetChatId(int userId, int otherUserId);

    }
}
