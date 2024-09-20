using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class MessageExtension
    {
        /// <summary>
        /// Converts a NewMessageDto object to a ChatMessage object.
        /// </summary>
        /// <param name="newMessage">The NewMessageDto object to convert.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="chatId">The chat ID.</param>
        /// <returns>The converted ChatMessage object.</returns>
        public static ChatMessage ToNewMessageDto(this NewMessageDto newMessage, int userId, int? chatId)
        {
            return new ChatMessage
            {
                ChatId = (int)chatId,
                SenderId = userId,
                FreeTxt = newMessage.Message,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

        /// <summary>
        /// Converts a Chat object to a ChatDto object.
        /// </summary>
        /// <param name="chat">The Chat object to convert.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The converted ChatDto object.</returns>
        public static ChatDto ToChatDto(this Chat chat, int userId)
        {
            return new ChatDto
            {
                Id = chat.Id,
                UserChatingId = chat.UserId1 == userId ? chat.UserId2 : chat.UserId1,
                Name = chat.UserId1 == userId ? chat.UserId2Navigation.Name + " " + chat.UserId2Navigation.Surname :
                chat.UserId1Navigation.Name + " " + chat.UserId1Navigation.Surname,
                LastMessage = chat.ChatMessages.Count > 0 ? chat.ChatMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().FreeTxt : null,
            };
        }

        /// <summary>
        /// Converts a list of Chat objects to a list of ChatDto objects.
        /// </summary>
        /// <param name="chats">The list of Chat objects to convert.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The converted list of ChatDto objects.</returns>
        public static List<ChatDto> ToChatDto(this List<Chat> chats, int userId)
        {
            List<ChatDto> chatDtos = new List<ChatDto>();
            foreach (var chat in chats)
            {
                chatDtos.Add(chat.ToChatDto(userId));
            }
            return chatDtos;
        }

        /// <summary>
        /// Converts a ChatMessage object to a MessageDto object.
        /// </summary>
        /// <param name="chatMessage">The ChatMessage object to convert.</param>
        /// <returns>The converted MessageDto object.</returns>
        public static MessageDto ToMessageDto(this ChatMessage chatMessage)
        {
            return new MessageDto
            {
                SenderId = chatMessage.SenderId,
                FreeTxt = chatMessage.FreeTxt,
                CreatedAt = chatMessage.CreatedAt.Date,
            };
        }

        /// <summary>
        /// Converts a list of ChatMessage objects to a list of MessageDto objects.
        /// </summary>
        /// <param name="chatMessages">The list of ChatMessage objects to convert.</param>
        /// <returns>The converted list of MessageDto objects.</returns>
        public static List<MessageDto> ToMessageDto(this List<ChatMessage> chatMessages)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var chatMessage in chatMessages)
            {
                messageDtos.Add(chatMessage.ToMessageDto());
            }
            return messageDtos;
        }

        /// <summary>
        /// Creates a new Chat object with the specified user IDs.
        /// </summary>
        /// <param name="userId1">The first user ID.</param>
        /// <param name="userId2">The second user ID.</param>
        /// <returns>The created Chat object.</returns>
        public static Chat ToChat(this int userId1, int userId2)
        {
            return new Chat
            {
                UserId1 = userId1,
                UserId2 = userId2,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                IsActive = true,
            };
        }
    }
}

