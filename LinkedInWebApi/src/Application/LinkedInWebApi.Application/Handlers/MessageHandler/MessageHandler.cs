using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Commands.Insert;
using LinkedInWebApi.Reposirotry.Commands.Read;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    public class MessageHandler : IMessageHandler
    {

        private readonly IMessageReadCommands _messageReadCommands;
        private readonly IMessageInsertCommands _messageInsertCommands;

        public MessageHandler(IMessageReadCommands messageReadCommands, IMessageInsertCommands messageInsertCommands)
        {
            _messageReadCommands = messageReadCommands;
            _messageInsertCommands = messageInsertCommands;
        }

        public Task<List<ChatDto>?> GetChatsOfUser(string userId)
        {

            return _messageReadCommands.GetChatsOfUser(int.Parse(userId));

        }


        public async Task<bool> InsertMessage(NewMessageDto newMessage)
        {
            return await _messageInsertCommands.InsertMessage(newMessage);
        }

        public async Task<List<MessageDto>?> GetMessageOfChat(int userId, int otherUserId)
        {
            return await _messageReadCommands.GetMessagesOfChat(userId, otherUserId);
        }


    }
}
