using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands.Read
{
    public interface IMessageReadCommands
    {

        Task<List<ChatDto>?> GetChatsOfUser(int userId);

        Task<List<MessageDto>?> GetMessagesOfChat(int userId, int otherUserId);

    }
}
