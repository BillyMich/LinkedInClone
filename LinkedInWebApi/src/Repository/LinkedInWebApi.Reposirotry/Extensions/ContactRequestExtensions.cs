using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    /// <summary>
    /// Extension methods for the ContactRequest class.
    /// </summary>
    public static class ContactRequestExtensions
    {
        /// <summary>
        /// Converts a NewContactRequestDto object to a ContactRequest object.
        /// </summary>
        /// <param name="contactRequestDto">The NewContactRequestDto object.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The converted ContactRequest object.</returns>
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

        /// <summary>
        /// Converts a ContactRequest object to a ContactRequestDto object.
        /// </summary>
        /// <param name="contactRequest">The ContactRequest object.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The converted ContactRequestDto object.</returns>
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

        /// <summary>
        /// Converts a list of ContactRequest objects to a list of ContactRequestDto objects.
        /// </summary>
        /// <param name="contactRequests">The list of ContactRequest objects.</param>
        /// <param name="userId">The user ID.</param>
        /// <returns>The converted list of ContactRequestDto objects.</returns>
        public static List<ContactRequestDto> ToContactRequestDto(this List<ContactRequest> contactRequests, int userId)
        {
            return contactRequests.Select(x => x.ToContactRequestDto(userId)).ToList();
        }
    }
}
