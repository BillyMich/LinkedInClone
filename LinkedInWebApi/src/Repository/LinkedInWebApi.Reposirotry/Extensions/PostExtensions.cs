﻿using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
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


        public static PostComment ToPostComment(this CreatePostCommentDto postDto, int userId)
        {
            return new PostComment
            {
                PostId = postDto.PostId,
                CreatorId = userId,
                FreeTxt = postDto.FreeTxt,
                IsActive = true,
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
                CreatorName = $"{post.Creator.Name} {post.Creator.Surname}",
                FreeTxt = post.FreeTxt,
                IsActive = post.IsActive,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Comments = post.PostComments?.ToList()?.ToCommentDto(),
                FileDto = post.PostMultimedia.FirstOrDefault()?.ToPostPhotoDto(),
                PostReactions = post.PostReactions.Count(),
            };
        }

        public static List<PostDto> ToPostDto(this List<Post> posts)
        {
            return posts.Select(x => x.ToPostDto()).ToList();
        }

        public static List<CommentDto>? ToCommentDto(this List<PostComment>? comments)
        {
            return comments?.Select(x => x.ToCommentDto()).ToList();
        }

        public static CommentDto ToCommentDto(this PostComment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                CreatorId = comment.CreatorId,
                CreatorName = comment.Creator.Name,
                FreeTxt = comment.FreeTxt,
                IsActive = comment.IsActive,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };
        }


        public static PostMultimedia ToPostMultimedia(this FileDto postPhotoDto)
        {
            return new PostMultimedia
            {
                FileName = postPhotoDto.FileName,
                DataOfFile = postPhotoDto.DataOfFile,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public static FileDto ToPostPhotoDto(this PostMultimedia postPhoto)
        {
            return new FileDto
            {
                FileName = postPhoto.FileName,
                DataOfFile = postPhoto.DataOfFile,
            };
        }

        public static PostReaction ToPostReaction(this LikePostDto likePostDto, int userId)
        {
            return new PostReaction
            {
                PostId = likePostDto.PostId,
                UserId = userId,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public static PostNotificationDto ToNotifications(this List<Post> posts)
        {
            return new PostNotificationDto
            {
                CommentNotifications = posts.SelectMany(x => x.PostComments.Select(y => new CommentNotificationDto
                {
                    PostId = x.Id,
                    UserId = y.CreatorId,
                    UserName = y.Creator.Name,
                    CommentTxt = y.FreeTxt,
                    CreatedAt = y.CreatedAt

                })).OrderBy(x => x.CreatedAt).ToList(),

                ReactionsNotifications = posts.SelectMany(x => x.PostReactions.Select(y => new PostReactionDto
                {
                    PostId = x.Id,
                    UserId = y.UserId,
                    UserName = y.User.Name,
                    CreatedAt = y.CreatedAt
                })).OrderBy(x => x.CreatedAt).ToList()
            };
        }

    }
}
