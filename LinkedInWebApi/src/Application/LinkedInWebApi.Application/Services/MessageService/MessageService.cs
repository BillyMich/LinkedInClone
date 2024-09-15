using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    /// <summary>
    /// Service class for handling messages.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IMessageReadCommands _messageReadCommands;
        private readonly IMessageInsertCommands _messageWriteCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="messageReadCommands">The message read commands.</param>
        /// <param name="messageWriteCommands">The message write commands.</param>
        public MessageService(IMessageReadCommands messageReadCommands, IMessageInsertCommands messageWriteCommands)
        {
            _messageReadCommands = messageReadCommands;
            _messageWriteCommands = messageWriteCommands;
        }

        /// <summary>
        /// Gets the chats of a user asynchronously.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of chat DTOs.</returns>
        public async Task<List<ChatDto>?> GetChatsOfUserAsync(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return await _messageReadCommands.GetChatsOfUserAsync(curentUserId);
        }

        /// <summary>
        /// Gets the messages of a chat asynchronously.
        /// </summary>
        /// <param name="getChatDto">The DTO containing chat details.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of message DTOs.</returns>
        public async Task<List<MessageDto>> GetMessageOfChatAsync(GetChatDto getChatDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var chatId = await _messageReadCommands.GetChatIdAsync(curentUserId, getChatDto.UserToChat);

            return await _messageReadCommands.GetMessagesOfChatAsync(chatId);
        }

        /// <summary>
        /// Inserts a new message asynchronously.
        /// </summary>
        /// <param name="newMessage">The DTO containing the new message details.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the message was inserted successfully, false otherwise.</returns>
        public async Task InsertMessageAsync(NewMessageDto newMessage, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var chatId = await _messageReadCommands.GetChatIdAsync(curentUserId, newMessage.ReceiverId);

            if (chatId == null)
            {
                chatId = await _messageWriteCommands.CreateChatAsync(curentUserId, newMessage.ReceiverId);
            }

            await _messageWriteCommands.InsertMessageAsync(newMessage, curentUserId, chatId);
        }
    }
}
