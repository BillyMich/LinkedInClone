using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    public class PostHandler : IPostHandler
    {
        private readonly IPostService _postService;

        public PostHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<bool> CreatePost(CreatePostDto postDto, ClaimsIdentity claimsIdentity)
        {
            return await _postService.CreatePost(postDto, claimsIdentity);
        }

        public Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(int id, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostComment(int id, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto?> GetPost(int id, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetPosts(ClaimsIdentity claimsIdentity)
        {
            return _postService.GetPosts(claimsIdentity);
        }

        public Task<bool> UpdatePost(PostDto postDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePostComment(PostCommentDto postCommentDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
