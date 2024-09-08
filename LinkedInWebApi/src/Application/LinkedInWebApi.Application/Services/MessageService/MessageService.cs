using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageReadCommands _messageReadCommands;
        private readonly IMessageInsertCommands _messageWriteCommands;

        public MessageService(IMessageReadCommands messageReadCommands, IMessageInsertCommands messageWriteCommands)
        {
            _messageReadCommands = messageReadCommands;
            _messageWriteCommands = messageWriteCommands;
        }


        public async Task<List<ChatDto>?> GetChatsOfUser(ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            return await _messageReadCommands.GetChatsOfUser(curentUserId);
        }

        public async Task<List<MessageDto>> GetMessageOfChat(GetChatDto getChatDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            var chatId = await _messageReadCommands.GetChatId(curentUserId, getChatDto.UserToChat);

            return await _messageReadCommands.GetMessagesOfChat(chatId);

        }

        public async Task<bool> InsertMessage(NewMessageDto newMessage, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            var chatId = await _messageReadCommands.GetChatId(curentUserId, newMessage.ReceiverId);

            return await _messageWriteCommands.InsertMessage(newMessage, curentUserId);
        }
    }
}
