using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IMessageService _messageService;

        public MessageHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<List<ChatDto>?> GetChatsOfUser(string userId, ClaimsIdentity claimsIdentity)
        {
            return await _messageService.GetChatsOfUser(claimsIdentity);
        }

        public async Task<List<MessageDto>> GetMessageOfChat(GetChatDto getChatDto, ClaimsIdentity claimsIdentity)
        {
            return await _messageService.GetMessageOfChat(getChatDto, claimsIdentity);
        }

        public async Task<bool> InsertMessage(NewMessageDto newMessage, ClaimsIdentity claimsIdentity)
        {
            return await _messageService.InsertMessage(newMessage, claimsIdentity);
        }
    }
}
