using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IMessageService
    {

        Task InsertMessageAsync(NewMessageDto newMessage, ClaimsIdentity claimsIdentity);

        Task<List<ChatDto>?> GetChatsOfUserAsync(ClaimsIdentity claimsIdentity);

        Task<List<MessageDto>> GetMessageOfChatAsync(GetChatDto getChatDto, ClaimsIdentity claimsIdentity);
    }
}
