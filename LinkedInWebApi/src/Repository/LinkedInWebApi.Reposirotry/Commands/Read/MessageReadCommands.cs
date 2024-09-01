using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands.Read
{
    public class MessageReadCommands : IMessageReadCommands
    {
        private readonly LinkedInDbContext linkedInDbContext;

        public MessageReadCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }

        public async Task<List<ChatDto>?> GetChatsOfUser(int userId)
        {
            var chats = await linkedInDbContext.Messages
                .Where(x => x.SenderId == userId || x.ResiverId == userId)
                .GroupBy(x => x.SenderId == userId ? x.ResiverId : x.SenderId)
                .Select(g => g.OrderByDescending(x => x.DateCreated).FirstOrDefault())
                .ToListAsync();

            if (chats == null || !chats.Any())
            {
                return null;
            }

            var userIds = chats.Select(chat => chat.SenderId == userId ? chat.ResiverId : chat.SenderId).ToList();
            var users = await linkedInDbContext.Users
                .Where(user => userIds.Contains(user.Id))
                .ToListAsync();

            var chatDto = chats.Select(chat =>
            {
                var otherUserId = chat.SenderId == userId ? chat.ResiverId : chat.SenderId;
                var otherUser = users.FirstOrDefault(user => user.Id == otherUserId);

                return new ChatDto
                {
                    Name = otherUser?.Name,
                    LastMessage = chat.FreeTxt,
                    LastMessageDate = chat.DateCreated.DateTime,
                    UserChatingId = otherUserId
                };
            }).ToList();

            return chatDto;
        }

        public async Task<List<MessageDto>?> GetMessagesOfChat(int userId, int otherUserId)
        {
            var messages = await linkedInDbContext.Messages
                .Where(x => (x.SenderId == userId && x.ResiverId == otherUserId) || (x.SenderId == otherUserId && x.ResiverId == userId))
                .OrderBy(x => x.DateCreated)
                .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return null;
            }

            var messageDto = messages.Select(message => new MessageDto
            {
                SenderId = message.SenderId,
                ReceiverId = message.ResiverId,
                Message = message.FreeTxt,
                DateCreated = message.DateCreated.DateTime
            }).ToList();

            return messageDto;
        }
    }
}
