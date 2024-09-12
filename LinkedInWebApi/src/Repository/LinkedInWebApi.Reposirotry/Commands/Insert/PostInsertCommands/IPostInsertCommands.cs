using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostInsertCommands
    {
        Task<bool> CreatePost(CreatePostDto postDto, FileDto fileDto, int userId);

        Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, int userId);

    }
}
