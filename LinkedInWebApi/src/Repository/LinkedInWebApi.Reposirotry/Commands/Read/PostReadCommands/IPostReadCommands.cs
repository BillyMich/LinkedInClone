using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostReadCommands
    {
        Task<List<PostDto>> GetPostByUserAsync(int userId);
        Task<FileDto> GetPostMultimedia(int id);
        Task<List<PostDto>> GetPosts();

    }
}
