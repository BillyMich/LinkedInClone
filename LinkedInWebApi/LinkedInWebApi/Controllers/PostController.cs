using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/post/")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostHandler _postHandler;
        private readonly ClaimsIdentity _identity;

        public PostController(IPostHandler postHandler, IHttpContextAccessor httpContextAccessor)
        {
            _postHandler = postHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        [HttpPost("CreatePost")]
        [Authorize]
        public async Task<ActionResult<PostDto>> CreatePost([FromForm] string FreeTxt, [FromForm] IFormFile? file)
        {
            try
            {
                var createPostDto = new CreatePostDto
                {
                    FreeTxt = FreeTxt,
                };
                return Ok(await _postHandler.CreatePost(createPostDto, file, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("UpdatePost")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdatePost([FromBody] PostDto postDto)
        {
            try
            {
                return Ok(await _postHandler.UpdatePost(postDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("DeletePost/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeletePost(int id)
        {
            try
            {
                return Ok(await _postHandler.DeletePost(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPost/{id}")]
        [Authorize]
        public async Task<ActionResult<PostDto?>> GetPost(int id)
        {
            try
            {
                return Ok(await _postHandler.GetPost(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPosts")]
        [Authorize]
        public async Task<ActionResult<List<PostDto>>?> GetPosts()
        {
            try
            {
                return Ok(await _postHandler.GetPosts(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreatePostComment")]
        [Authorize]

        public async Task<ActionResult<bool>> CreatePostComment([FromBody] CreatePostCommentDto createPostCommentDto)
        {
            try
            {
                return Ok(await _postHandler.CreatePostComment(createPostCommentDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdatePostComment")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdatePostComment([FromBody] PostCommentDto postCommentDto)
        {
            try
            {
                return Ok(await _postHandler.UpdatePostComment(postCommentDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("DeletePostComment/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeletePostComment(int id)
        {
            try
            {
                return Ok(await _postHandler.DeletePostComment(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPostMultimedia/{id}")]
        [Authorize]
        public async Task<ActionResult> GetPostMultimedia(int id)
        {
            try
            {
                var fileDto = await _postHandler.GetPostMultimedia(id, _identity);

                if (fileDto == null)
                {
                    return NoContent();
                }

                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(fileDto.FileName, out var contentType))
                {
                    contentType = "application/octet-stream"; // Default to binary stream if MIME type is not found
                }

                return new FileContentResult(fileDto.DataOfFile, contentType)
                {
                    FileDownloadName = fileDto.FileName
                };
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetNotificationInPost")]
        [Authorize]
        public async Task<ActionResult<PostNotificationDto>> GetNotificationInPost()
        {
            try
            {
                return Ok(await _postHandler.GetNotificationInPost(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
