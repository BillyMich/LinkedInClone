using LinkedInWebApi.Application.Extensions;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostInsertCommands _postInsertCommands;
        private readonly IPostReadCommands _postReadCommands;

        public PostService(IPostInsertCommands postInsertCommands, IPostReadCommands postReadCommands)
        {
            _postInsertCommands = postInsertCommands;
            _postReadCommands = postReadCommands;
        }

        public Task<bool> CreatePost(CreatePostDto createPostDto, IFormFile file, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            var fileDto = file != null ? file.ConvertToFileDto() : null;

            return _postInsertCommands.CreatePost(createPostDto, fileDto, curentUserId);
        }

        public Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);

            return _postInsertCommands.CreatePostComment(postCommentDto, curentUserId);
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

        public async Task<FileDto> GetPostMultimedia(int id, ClaimsIdentity identity)
        {
            return await _postReadCommands.GetPostMultimedia(id);
        }

        public async Task<List<PostDto>> GetPosts(ClaimsIdentity claimsIdentity)
        {
            return await _postReadCommands.GetPosts();
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
