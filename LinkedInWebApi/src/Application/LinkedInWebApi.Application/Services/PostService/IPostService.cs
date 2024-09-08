﻿using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public interface IPostService
    {
        Task<int> CreatePost(CreatePostDto postDto, ClaimsIdentity claimsIdentity);

        Task<bool> UpdatePost(PostDto postDto, ClaimsIdentity claimsIdentity);

        Task<bool> DeletePost(int id, ClaimsIdentity claimsIdentity);

        Task<PostDto?> GetPost(int id, ClaimsIdentity claimsIdentity);

        Task<List<PostDto>> GetPosts(ClaimsIdentity claimsIdentity);

        Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, ClaimsIdentity claimsIdentity);

        Task<bool> UpdatePostComment(PostCommentDto postCommentDto, ClaimsIdentity claimsIdentity);

        Task<bool> DeletePostComment(int id, ClaimsIdentity claimsIdentity);
    }
}
