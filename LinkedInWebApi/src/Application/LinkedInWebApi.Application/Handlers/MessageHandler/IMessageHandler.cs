using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    public interface IMessageHandler
    {

        Task<bool> InsertMessageAsync(NewMessageDto newMessage, ClaimsIdentity claimsIdentity);

        Task<List<ChatDto>?> GetChatsOfUserAsync(ClaimsIdentity claimsIdentity);

        Task<List<MessageDto>> GetMessageOfChatAsync(GetChatDto getChatDto, ClaimsIdentity claimsIdentity);

    }
}
