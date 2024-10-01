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

        public async Task<List<NotificationDto>> GetNotificationInPost(int userId)
        {

            try
            {
                var notifications = await _linkedInDbContext.Posts
                    .Where(x => x.CreatorId == userId)
                    .Include(x => x.PostComments)
                    .Select(post => new NotificationDto
                    {
                        PostId = post.Id,
                        CommentCount = post.PostComments.Count
                    })
                    .ToListAsync();

                return notifications;

            }
            catch (Exception ex)
            {
                throw ex;
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
                    Include(x => x.Creator).
                    Include(x => x.PostMultimedia).ToListAsync();
                return posts.ToPostDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
