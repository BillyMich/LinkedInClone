using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
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

        public Task<bool> CreatePost(CreatePostDto createPostDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserId(claimsIdentity);

            return _postInsertCommands.CreatePost(createPostDto, curentUserId);
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
