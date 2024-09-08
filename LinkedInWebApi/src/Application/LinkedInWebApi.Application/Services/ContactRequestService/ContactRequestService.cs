using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Commands;

namespace LinkedInWebApi.Application.Services
{
    public class ContactRequestService : IContactRequestService
    {
        private readonly IContactRequestUpdateCommands _contactRequestUpdateCommands;
        private readonly IContactRequestReadCommands _contactRequestReadCommands;
        private readonly IContactRequestInsertCommands _contactRequestInsertCommands;

        public ContactRequestService(IContactRequestUpdateCommands contactRequestUpdateCommands, IContactRequestReadCommands contactRequestReadCommands, IContactRequestInsertCommands contactRequestInsertCommands)
        {
            _contactRequestUpdateCommands = contactRequestUpdateCommands;
            _contactRequestReadCommands = contactRequestReadCommands;
            _contactRequestInsertCommands = contactRequestInsertCommands;
        }


        public Task<bool> ChangeStatusOfRequest(int requestId, bool status)
        {
            return _contactRequestUpdateCommands.ChangeStatusOfRequest(requestId, status);
        }

        public Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto)
        {
            return _contactRequestInsertCommands.CreateContactRequest(contactRequestDto);
        }

        public Task<List<ContactRequestDto>> GetConnectedContactsByStatus(int userId, int statusId)
        {
            return _contactRequestReadCommands.GetConnectedContactsByStatus(userId, statusId);
        }

        public Task<List<UserDto>> GetConnectedUsers(int userId)
        {
            return _contactRequestReadCommands.GetConnectedUsers(userId);
        }
    }
}
