using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Core;
using LinkedInWebApi.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {

        IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }


        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getUser/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto?>> GetUser(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var result = await _userHandler.GetUserHandler(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsers")]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] List<int>? ids)
        {
            var result = await _userHandler.GetUsersHandler();
            return Ok(result);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpPost("getConectedUsers")]
        public async Task<ActionResult<List<UserDto>>> GetConectedUsers()
        {
            var result = await _userHandler.GetUsersHandler();
            return Ok(result);
        }


        [HttpPost("getUsersXML")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetUsersXML(List<int>? ids)
        {
            try
            {
                return await _userHandler.GetUsersToXML(ids);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("getUsersJson")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetUsersJson(List<int>? ids)
        {
            try
            {
                return await _userHandler.GetUsersToJson(ids);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("updateUserSettings")]
        public async Task<ActionResult> UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto)
        {
            try
            {
                await _userHandler.UpdateUserSettings(updateUserSettingsDto);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("updateProfilePicture")]
        public async Task<ActionResult> UpdateProfilePicture(IFormFile file)
        {
            try
            {
                await _userHandler.UpdateUserSettings(updateUserSettingsDto);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
