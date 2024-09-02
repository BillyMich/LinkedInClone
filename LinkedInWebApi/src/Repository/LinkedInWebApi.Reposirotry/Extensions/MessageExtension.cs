using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class MessageExtension
    {



        public static ChatMessage ToNewMessageDto(this NewMessageDto newMessage)
        {

            return new ChatMessage
            {
                SenderId = newMessage.SenderId,
                FreeTxt = newMessage.Message,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

    }
}

