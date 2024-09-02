using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IMessageInsertCommands
    {
        Task<bool> InsertMessage(NewMessageDto newMessage);
    }
}
