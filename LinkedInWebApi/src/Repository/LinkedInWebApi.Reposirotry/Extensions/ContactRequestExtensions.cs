using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class ContactRequestExtensions
    {

        public static ContactRequest ToContanctRequest(this ContactRequestDto contactRequestDto, int userId)
        {
            return new ContactRequest
            {
                UserRequestId = userId,
                UserResiverId = contactRequestDto.UserResiverId,
                IsActive = true,
                IsAccepted = false,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public static ContactRequestDto ToContactRequestDto(this ContactRequest contactRequest)
        {
            return new ContactRequestDto
            {
                Id = contactRequest.Id,
                UserResiverId = contactRequest.UserResiverId,
                IsActive = contactRequest.IsActive,
                IsAccepted = contactRequest.IsAccepted,
                CreatedAt = contactRequest.CreatedAt,
                UpdatedAt = contactRequest.UpdatedAt
            };
        }

        public static List<ContactRequestDto> ToContactRequestDto(this List<ContactRequest> contactRequests)
        {
            return contactRequests.Select(x => x.ToContactRequestDto()).ToList();
        }
    }
}
