namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IContactRequestUpdateCommands
    {
        Task<bool> ChangeStatusOfRequest(int requestId, bool status);

    }
}
