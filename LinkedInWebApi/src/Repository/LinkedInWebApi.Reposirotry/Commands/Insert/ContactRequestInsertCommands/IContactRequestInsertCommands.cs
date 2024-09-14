using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestInsertCommands
    {
        Task<bool> CreateContactRequest(NewContactRequestDto contactRequestDto, int userId);
    }
}
