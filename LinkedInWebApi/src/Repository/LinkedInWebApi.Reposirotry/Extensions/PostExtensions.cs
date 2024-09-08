using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class PostExtensions
    {

        public static Post ToPost(this CreatePostCommentDto postDto, int userId)
        {
            return new Post
            {
                CreatorId = userId,
                Title = postDto.Title,
                FreeTxt = postDto.FreeTxt,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }


    }
}
