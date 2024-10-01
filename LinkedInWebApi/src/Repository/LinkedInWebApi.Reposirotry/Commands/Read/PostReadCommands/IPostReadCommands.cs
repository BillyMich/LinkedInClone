using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostReadCommands
    {
        Task<List<NotificationDto>> GetNotificationInPost(int userId);
        Task<FileDto> GetPostMultimedia(int id);
        Task<List<PostDto>> GetPosts();

    }
}
