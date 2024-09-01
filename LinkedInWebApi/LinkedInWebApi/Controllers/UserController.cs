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
        [HttpPost("getUsers")]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var result = await _userHandler.GetUsersHandler();
            return Ok(result);
        }


        [HttpGet("getUsersXML")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetUsersXML([FromQuery] List<int>? ids)
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

        [HttpGet("getUsersJson")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> GetUsersJson([FromQuery] List<int>? ids)
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

        [HttpPost("update-User-Settings")]
        public async Task<ActionResult<UpdateUserSettingsDto>> UpdateUserSettings(UpdateUserSettingsDto updateUserSettingsDto)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
