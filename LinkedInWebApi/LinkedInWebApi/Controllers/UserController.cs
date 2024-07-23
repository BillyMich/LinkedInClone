using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("getUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto?>> GetUser(int id)
        {
            try
            {
                var result = await _userHandler.GetUserHandler(id);

                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("getUsers")]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            try
            {
                var result = await _userHandler.GetUsersHandler();

                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpPost("getUsersXML")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetUsersXML()
        {
            try
            {
                var result = await _userHandler.GetUsersToXML();

                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }

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
