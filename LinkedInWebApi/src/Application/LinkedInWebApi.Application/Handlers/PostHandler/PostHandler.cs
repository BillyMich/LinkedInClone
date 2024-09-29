using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;
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

        public async Task<bool> CreatePost(CreatePostDto postDto, IFormFile? file, ClaimsIdentity claimsIdentity)
        {
            return await _postService.CreatePost(postDto, file, claimsIdentity);
        }

        public async Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, ClaimsIdentity claimsIdentity)
        {
            return await _postService.CreatePostComment(postCommentDto, claimsIdentity);
        }

        public async Task<bool> DeletePost(int id, ClaimsIdentity claimsIdentity)
        {
            return await _postService.DeletePost(id, claimsIdentity);
        }

        public async Task<bool> DeletePostComment(int id, ClaimsIdentity claimsIdentity)
        {
            return await _postService.DeletePostComment(id, claimsIdentity);
        }

        public Task<List<NotificationDto>> GetNotificationInPost(ClaimsIdentity identity)
        {
            return _postService.GetNotificationInPost(identity);
        }

        public Task<PostDto?> GetPost(int id, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDto> GetPostMultimedia(int id, ClaimsIdentity identity)
        {
            return await _postService.GetPostMultimedia(id, identity);
        }

        public Task<List<PostDto>> GetPosts(ClaimsIdentity claimsIdentity)
        {
            return _postService.GetPosts(claimsIdentity);
        }

        public Task<bool> UpdatePost(PostDto postDto, ClaimsIdentity claimsIdentity)
        {
            return _postService.UpdatePost(postDto, claimsIdentity);
        }

        public Task<bool> UpdatePostComment(PostCommentDto postCommentDto, ClaimsIdentity claimsIdentity)
        {
            return _postService.UpdatePostComment(postCommentDto, claimsIdentity);
        }
    }
}
