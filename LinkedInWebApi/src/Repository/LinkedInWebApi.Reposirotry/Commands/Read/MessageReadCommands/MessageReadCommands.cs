using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class MessageReadCommands : IMessageReadCommands
    {
        private readonly LinkedInDbContext linkedInDbContext;

        public MessageReadCommands(LinkedInDbContext linkedInDbContext)
        {
            this.linkedInDbContext = linkedInDbContext;
        }

        public async Task<List<ChatDto>?> GetChatsOfUser(int userId)
        {


            return null;
        }

        public async Task<List<MessageDto>?> GetMessagesOfChat(int userId, int otherUserId)
        {


            return null;
        }
    }
}
