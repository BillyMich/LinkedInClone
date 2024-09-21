using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostReadCommands
    {
        Task<FileDto> GetPostMultimedia(int id);
        Task<List<PostDto>> GetPosts();

    }
}
