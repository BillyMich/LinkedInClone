using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class PostReadCommands : IPostReadCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public PostReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public Task<List<PostDto>> GetPostByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDto?> GetPostMultimedia(int id)
        {
            try
            {
                var postMultimedia = await _linkedInDbContext.PostMultimedia.FirstOrDefaultAsync(x => x.PostId == id);
                if (postMultimedia == null) { return null; }
                return postMultimedia.ToPostPhotoDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<PostDto>> GetPosts()
        {
            try
            {
                var posts = await _linkedInDbContext.Posts.
                    Include(x => x.PostComments).
                    ThenInclude(x => x.Creator).
                    Include(x => x.Creator).
                    Include(x => x.PostMultimedia).
                    Include(x => x.PostReactions).
                    Include(x => x.PostReactions)
                    .ToListAsync();
                return posts.ToPostDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
