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

        public async Task<List<PostDto>> GetPosts()
        {
            try
            {
                var posts = await _linkedInDbContext.Posts.
                    Include(x => x.PostComments).
                    Include(x => x.Creator).
                    Include(x => x.PostPhotos).ToListAsync();
                return posts.ToPostDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
