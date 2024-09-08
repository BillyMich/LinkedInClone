using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    public interface IMessageHandler
    {

        Task<bool> InsertMessage(NewMessageDto newMessage, ClaimsIdentity claimsIdentity);

        Task<List<ChatDto>?> GetChatsOfUser(string userId, ClaimsIdentity claimsIdentity);

        Task<List<MessageDto>> GetMessageOfChat(GetChatDto getChatDto, ClaimsIdentity claimsIdentity);

    }
}
