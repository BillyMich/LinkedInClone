using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// Represents a class that provides read operations for messages.
    /// </summary>
    public class MessageReadCommands : IMessageReadCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReadCommands"/> class.
        /// </summary>
        /// <param name="linkedInDbContext">The LinkedIn database context.</param>
        public MessageReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Gets the chat ID for the given user IDs.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="otherUserId">The other user ID.</param>
        /// <returns>The chat ID if found, otherwise null.</returns>
        public async Task<int?> GetChatIdAsync(int userId, int otherUserId)
        {
            try
            {
                var chat = await _linkedInDbContext.Chats.Where
                    (x => x.UserId1 == userId && x.UserId2 == otherUserId || x.UserId1 == otherUserId && x.UserId2 == userId).
                    FirstOrDefaultAsync();
                return chat?.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the chats of the specified user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The list of chats if found, otherwise null.</returns>
        public async Task<List<ChatDto>?> GetChatsOfUserAsync(int userId)
        {
            try
            {
                var chats = await _linkedInDbContext.Chats.Where(x => x.UserId1 == userId || x.UserId2 == userId)
                    .Include(x => x.UserId1Navigation)
                    .Include(x => x.UserId2Navigation)
                    .ToListAsync();
                return chats.ToChatDto(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the messages of the specified chat.
        /// </summary>
        /// <param name="chatId">The chat ID.</param>
        /// <returns>The list of messages if found, otherwise null.</returns>
        public async Task<List<MessageDto>?> GetMessagesOfChatAsync(int? chatId)
        {
            try
            {
                var messages = await _linkedInDbContext.ChatMessages.Where(x => x.ChatId == chatId)
                    .OrderBy(x => x.CreatedAt)
                    .ToListAsync();
                return messages.ToMessageDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
