using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/post/")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostHandler _postHandler;
        private readonly ClaimsIdentity _identity;

        public PostController(IPostHandler postHandler, ClaimsIdentity identity)
        {
            _postHandler = postHandler;
            _identity = identity;
        }

        [HttpPost("CreatePost")]
        public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            try
            {
                return Ok(await _postHandler.CreatePost(createPostDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdatePost")]
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

    }
}
