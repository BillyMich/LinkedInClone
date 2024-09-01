using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands.Insert
{
    public class MessageInsertCommands : IMessageInsertCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;
        public MessageInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> InsertMessage(NewMessageDto newMessage)
        {

            var message = newMessage.ToNewMessageDto();

            _linkedInDbContext.Messages.Add(message);
            await _linkedInDbContext.SaveChangesAsync();
            return true;
        }
    }
}
