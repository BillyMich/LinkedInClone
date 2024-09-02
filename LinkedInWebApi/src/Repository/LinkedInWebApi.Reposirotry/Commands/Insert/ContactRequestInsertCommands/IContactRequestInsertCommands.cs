using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestInsertCommands
    {
        Task<bool> CreateContactRequest(ContactRequestDto contactRequestDto);
    }
}
