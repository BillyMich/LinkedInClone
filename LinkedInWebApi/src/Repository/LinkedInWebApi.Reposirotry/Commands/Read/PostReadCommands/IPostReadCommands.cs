using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostReadCommands
    {
        Task<PostNotificationDto> GetPostNotificationByUserAsync(int curentUserId);
        Task<FileDto> GetPostMultimedia(int id);
        Task<List<PostDto>> GetPosts();

    }
}
