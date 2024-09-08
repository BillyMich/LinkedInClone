using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IMessageService
    {

        Task<bool> InsertMessage(NewMessageDto newMessage, ClaimsIdentity claimsIdentity);

        Task<List<ChatDto>?> GetChatsOfUser(ClaimsIdentity claimsIdentity);

        Task<List<MessageDto>> GetMessageOfChat(GetChatDto getChatDto, ClaimsIdentity claimsIdentity);
    }
}
