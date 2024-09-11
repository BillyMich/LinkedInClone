using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostReadCommands
    {

        Task<List<PostDto>> GetPosts();

    }
}
