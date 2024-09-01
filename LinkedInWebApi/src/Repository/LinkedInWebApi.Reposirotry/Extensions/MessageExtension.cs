using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain.Entities;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class MessageExtension
    {



        public static Message ToNewMessageDto(this NewMessageDto newMessage)
        {

            return new Message
            {
                SenderId = newMessage.SenderId,
                ResiverId = newMessage.ReceiverId,
                FreeTxt = newMessage.Message,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
            };
        }

    }
}

