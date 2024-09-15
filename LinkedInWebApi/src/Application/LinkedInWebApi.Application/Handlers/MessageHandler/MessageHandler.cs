using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    /// <summary>
    /// Represents a message handler that handles various operations related to messages.
    /// </summary>
    public class MessageHandler : IMessageHandler
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandler"/> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        public MessageHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Gets the chats of a user asynchronously.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of chat DTOs.</returns>
        public async Task<List<ChatDto>?> GetChatsOfUserAsync(ClaimsIdentity claimsIdentity)
        {
            return await _messageService.GetChatsOfUserAsync(claimsIdentity);
        }

        /// <summary>
        /// Gets the messages of a chat asynchronously.
        /// </summary>
        /// <param name="getChatDto">The DTO containing information about the chat.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of message DTOs.</returns>
        public async Task<List<MessageDto>> GetMessageOfChatAsync(GetChatDto getChatDto, ClaimsIdentity claimsIdentity)
        {
            return await _messageService.GetMessageOfChatAsync(getChatDto, claimsIdentity);
        }

        /// <summary>
        /// Inserts a new message asynchronously.
        /// </summary>
        /// <param name="newMessage">The DTO containing information about the new message.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the message is inserted successfully, otherwise false.</returns>
        public async Task InsertMessageAsync(NewMessageDto newMessage, ClaimsIdentity claimsIdentity)
        {
            await _messageService.InsertMessageAsync(newMessage, claimsIdentity);
        }
    }
}
