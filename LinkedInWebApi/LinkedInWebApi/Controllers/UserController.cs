using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserHandler _userHandler;
        private readonly ClaimsIdentity _identity;


        public UserController(IUserHandler userHandler, IHttpContextAccessor httpContextAccessor)
        {
            _userHandler = userHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userHandler.GetUserHandlerAsync(id, _identity);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userHandler.GetUsersHandlerAsync(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpGet("getUsersToXML")]
        public async Task<IActionResult> GetUsersToXML(List<int>? ids)
        {
            try
            {
                return await _userHandler.GetUsersToXMLAsync(ids, _identity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getUsersToJson")]
        public async Task<IActionResult> GetUsersToJson(List<int>? ids)
        {
            try
            {
                return await _userHandler.GetUsersToJson(ids, _identity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("updateUserSettings")]
        public async Task<IActionResult> UpdateUserSettings([FromBody] UpdateUserSettingsDto updateUserSettingsDto)
        {
            try
            {
                await _userHandler.UpdateUserSettingsAsync(updateUserSettingsDto, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getConectedUsers")]
        public async Task<IActionResult> GetConectedUsers()
        {
            try
            {
                return Ok(await _userHandler.GetUsersHandlerAsync(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("updateProfilePicture")]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] IFormFile file)
        {
            try
            {
                await _userHandler.UpdateProfilePictureAsync(file, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProfilePictureFromId/{id}")]
        public async Task<IActionResult> GetProfilePictureFromId(int id)
        {

            var fileDto = await _userHandler.GetProfilePictureFromIdAsync(id);

            return new FileContentResult(fileDto.DataOfFile, "image/jpeg")
            {
                FileDownloadName = fileDto.FileName
            };
        }

        [HttpPost("updateUserCV")]
        public async Task<IActionResult> updateUserCV([FromForm] IFormFile file)
        {
            try
            {
                await _userHandler.UpdateUserCVAsync(file, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
