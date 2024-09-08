using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class MessageExtension
    {



        public static ChatMessage ToNewMessageDto(this NewMessageDto newMessage, int userId)
        {

            return new ChatMessage
            {
                SenderId = userId,
                FreeTxt = newMessage.Message,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

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

        public static List<ChatDto> ToChatDto(this List<Chat> chats, int userId)
        {
            List<ChatDto> chatDtos = new List<ChatDto>();
            foreach (var chat in chats)
            {
                chatDtos.Add(chat.ToChatDto(userId));
            }
            return chatDtos;
        }

        public static MessageDto ToMessageDto(this ChatMessage chatMessage)
        {
            return new MessageDto
            {
                SenderId = chatMessage.SenderId,
                FreeTxt = chatMessage.FreeTxt,
                CreatedAt = chatMessage.CreatedAt.Date,
            };
        }

        public static List<MessageDto> ToMessageDto(this List<ChatMessage> chatMessages)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var chatMessage in chatMessages)
            {
                messageDtos.Add(chatMessage.ToMessageDto());
            }
            return messageDtos;
        }



    }
}

