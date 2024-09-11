﻿using LinkedInWebApi.Core;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public interface IPostInsertCommands
    {
        Task<bool> CreatePost(CreatePostDto postDto, int userId);

        Task<bool> CreatePostComment(CreatePostCommentDto postCommentDto, int userId);

    }
}
