using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class PostService : IPostService
    {
        public Task<int> CreatePost(CreatePostDto postDto, ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
