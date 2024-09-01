using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Application.Handlers.MessageHandler
{
    public interface IMessageHandler
    {

        Task<List<ChatDto>?> GetChatsOfUser(string userId);

        Task<bool> InsertMessage(NewMessageDto newMessage);

        Task<List<MessageDto>> GetMessageOfChat(GetChatDto getChatDto);


    }
}
