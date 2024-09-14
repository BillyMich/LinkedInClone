using LinkedInWebApi.Core;
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

        public async Task<int> CreateChatAsync(int userId1, int userId2)
        {
            try
            {
                var newChat = userId1.ToChat(userId2);
                _linkedInDbContext.Chats.Add(newChat);
                await _linkedInDbContext.SaveChangesAsync();
                return newChat.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method is used to insert a new message
        /// </summary>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> InsertMessageAsync(NewMessageDto newMessage, int userId, int? chatId)
        {

            try
            {
                _linkedInDbContext.ChatMessages.Add(newMessage.ToNewMessageDto(userId, chatId));
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
