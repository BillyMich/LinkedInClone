using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class PostInsertCommands : IPostInsertCommands
    {
        private readonly LinkedInDbContext _linkedInDbContext;

        public PostInsertCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<bool> CreatePost(CreatePostDto createPostDto, FileDto fileDto, int userId)
        {
            try
            {
                var post = createPostDto.ToPost(userId);
                if (fileDto != null)
                {
                    post.PostMultimedia.Add(fileDto.ToPostMultimedia());
                }
                await _linkedInDbContext.Posts.AddAsync(post);
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, int userId)
        {
            try
            {
                var postComment = postCommentDto.ToPostComment(userId);
                await _linkedInDbContext.PostComments.AddAsync(postComment);
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> LikePostAsync(LikePostDto likePostDto, int v)
        {
            try
            {
                var porsReaction = likePostDto.ToPostReaction(v);
                await _linkedInDbContext.PostReactions.AddAsync(porsReaction);
                await _linkedInDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
