using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Core;
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
        [HttpPost("getUser")]
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


        [HttpPost("getUsersXML")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetUsersXML()
        {
                var result = await _userHandler.GetUsersToXML();
                return Ok(result);
        }

        [HttpPost("getUsersJson")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetUsersJson()
        {
            try
            {
                var result = await _userHandler.GetUsersToJson();

                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
