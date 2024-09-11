using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class PostExtensions
    {

        public static Post ToPost(this CreatePostDto postDto, int userId)
        {
            return new Post
            {
                CreatorId = userId,
                FreeTxt = postDto.FreeTxt,
                IsActive = true,
                Status = 1,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }


        public static Post ToPost(this CreatePostCommentDto postDto, int userId)
        {
            return new Post
            {
                CreatorId = userId,
                FreeTxt = postDto.FreeTxt,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                CreatorId = post.CreatorId,
                FreeTxt = post.FreeTxt,
                IsActive = post.IsActive,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }

        public static List<PostDto> ToPostDto(this List<Post> posts)
        {
            return posts.Select(x => x.ToPostDto()).ToList();
        }


    }
}
