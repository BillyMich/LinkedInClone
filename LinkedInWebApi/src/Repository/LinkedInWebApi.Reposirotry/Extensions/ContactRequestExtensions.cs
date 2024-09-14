using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class ContactRequestExtensions
    {

        public static ContactRequest ToNewContanctRequest(this NewContactRequestDto contactRequestDto, int userId)
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

        public static ContactRequestDto ToContactRequestDto(this ContactRequest contactRequest, int userId)
        {
            return new ContactRequestDto
            {
                Id = contactRequest.Id,
                Name = contactRequest.UserRequestId == userId ? contactRequest.UserResiver.Name + " " + contactRequest.UserResiver.Surname :
                contactRequest.UserRequest.Name + " " + contactRequest.UserRequest.Surname,
                UserResiverId = contactRequest.UserResiverId,
                IsAccepted = contactRequest.IsAccepted,
            };
        }

        public static List<ContactRequestDto> ToContactRequestDto(this List<ContactRequest> contactRequests, int userId)
        {
            return contactRequests.Select(x => x.ToContactRequestDto(userId)).ToList();
        }
    }
}
