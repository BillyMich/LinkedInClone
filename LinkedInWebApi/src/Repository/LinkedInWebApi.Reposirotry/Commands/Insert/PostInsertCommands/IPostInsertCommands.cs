using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostInsertCommands
    {
        Task<bool> CreatePost(CreatePostDto postDto, FileDto fileDto, int userId);
        Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, int userId);
        Task<bool> LikePostAsync(LikePostDto likePostDto, int v);
    }
}
