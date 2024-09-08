using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class MessageReadCommands : IMessageReadCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        public MessageReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<int> GetChatId(int userId, int otherUserId)
        {
            try
            {
                var chat = await _linkedInDbContext.Chats.Where
                    (x => x.UserId1 == userId && x.UserId2 == otherUserId || x.UserId1 == otherUserId && x.UserId2 == userId).
                    FirstOrDefaultAsync();

                return chat.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ChatDto>?> GetChatsOfUser(int userId)
        {

            try
            {
                var chats = await _linkedInDbContext.Chats.Where(x => x.UserId1 == userId || x.UserId2 == userId).ToListAsync();
                return chats.ToChatDto(userId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MessageDto>?> GetMessagesOfChat(int chatId)
        {

            try
            {
                var messages = await _linkedInDbContext.ChatMessages.Where(x => x.ChatId == chatId).
                    OrderBy(x => x.CreatedAt).ToListAsync();

                return messages.ToMessageDto();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
