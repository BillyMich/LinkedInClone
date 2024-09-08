using LinkedInWebApi.Core;
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

        public async Task<bool> CreatePost(CreatePostCommentDto createPostDto, int userId)
        {
            try
            {
                var post = createPostDto.ToPost(userId);
                await _linkedInDbContext.Posts.AddAsync(post);
                await _linkedInDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
