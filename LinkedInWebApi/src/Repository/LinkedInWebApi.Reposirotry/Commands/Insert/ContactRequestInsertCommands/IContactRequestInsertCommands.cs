using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestInsertCommands
    {
        Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto, int userId);
    }
}
