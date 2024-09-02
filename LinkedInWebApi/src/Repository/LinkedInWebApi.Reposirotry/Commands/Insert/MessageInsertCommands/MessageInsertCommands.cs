using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class MessageInsertCommands : IMessageInsertCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public MessageInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// This method is used to insert a new message
        /// </summary>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> InsertMessage(NewMessageDto newMessage)
        {

            try
            {
                _linkedInDbContext.ChatMessages.Add(newMessage.ToNewMessageDto());
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
