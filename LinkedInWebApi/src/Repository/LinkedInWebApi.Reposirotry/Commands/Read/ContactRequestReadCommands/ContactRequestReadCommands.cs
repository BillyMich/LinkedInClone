using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    /// <summary>
    /// This class provides read operations for contact requests.
    /// </summary>
    public class ContactRequestReadCommands : IContactRequestReadCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        public ContactRequestReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        /// <summary>
        /// Retrieves a list of pending connect contacts for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of contact requests as ContactRequestDto.</returns>
        public async Task<List<ContactRequestDto>> GetPendingConnectContactsAsync(int userId)
        {
            var contactRequests = await _linkedInDbContext.ContactRequests
                .Include(x => x.UserRequest)
                .Include(x => x.UserResiver)
                .Where(x => x.UserRequestId == userId || x.UserResiverId == userId)
                .Where(x => x.IsActive == true && x.IsAccepted == false)
                .ToListAsync();

            return contactRequests.ToContactRequestDto(userId);
        }

        /// <summary>
        /// Retrieves a list of connected users for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of connected users as UserDto.</returns>
        public async Task<List<UserDto>> GetConnectedUsersAsync(int userId)
        {
            var connectedUsers = await _linkedInDbContext.ContactRequests
                .Where(x => x.UserRequestId == userId || x.UserResiverId == userId)
                .Where(x => x.IsActive == true && x.IsAccepted == true)
                .Select(x => new UserDto
                {
                    Id = x.UserRequestId == userId ? x.UserResiverId : x.UserRequestId,
                    Name = x.UserRequestId == userId ? x.UserResiver.Name : x.UserRequest.Name,
                    Surname = x.UserRequestId == userId ? x.UserResiver.Surname : x.UserRequest.Surname,
                    Email = x.UserRequestId == userId ? x.UserResiver.Email : x.UserRequest.Email,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .ToListAsync();

            return connectedUsers;
        }
    }
}
