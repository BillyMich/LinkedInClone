using LinkedInWebApi.Core.Dto;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class ContactRequestExtensions
    {

        public static ContactRequest ToContanctRequest(this ContactRequestDto contactRequestDto)
        {
            return new ContactRequest
            {
                UserRequestId = contactRequestDto.UserRequestId,
                UserResiverId = contactRequestDto.UserResiverId,
                IsActive = true,
                IsAccepted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }
    }
}
