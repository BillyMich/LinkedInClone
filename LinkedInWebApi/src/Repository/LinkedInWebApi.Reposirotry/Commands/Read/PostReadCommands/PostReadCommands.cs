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

        public async Task<PostNotificationDto> GetPostNotificationByUserAsync(int userId)
        {
            try
            {
                var postByUser = await _linkedInDbContext.Posts.Where(x => x.CreatorId == userId && x.IsActive == true)
                    .Include(u => u.PostComments)
                    .ThenInclude(u => u.Creator)
                    .Include(z => z.PostReactions)
                    .ThenInclude(z => z.User)
                    .ToListAsync();

                return postByUser.ToNotifications();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FileDto?> GetPostMultimedia(int id)
        {
            try
            {
                var postMultimedia = await _linkedInDbContext.PostMultimedia.FirstOrDefaultAsync(x => x.PostId == id);
                if (postMultimedia == null) { return null; }
                return postMultimedia.ToPostPhotoDto();
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

    }

}
