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
        public async Task<IActionResult> UpdateUserCV([FromForm] IFormFile file)
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

        [HttpPost("updateUserExperience")]
        public async Task<IActionResult> UpdateUserExperience([FromBody] CreateUserExperienceDto createUserExperience)
        {
            try
            {
                await _userHandler.UpdateUserExperienceAsync(createUserExperience, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("removeUserExperience")]
        public async Task<IActionResult> RemoveUpdateUserExperience([FromBody] int userExperienceId)
        {
            try
            {
                await _userHandler.RemoveUserExperienceAsync(userExperienceId, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("updateUserEducation")]
        public async Task<IActionResult> UpdateUserEducation([FromBody] CreateUserEducationDto createUserEducation)
        {
            try
            {
                await _userHandler.UpdateUserEducationAsync(createUserEducation, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("removeUserEducation")]
        public async Task<IActionResult> RemoveUpdateUserEducation([FromBody] int userEducationId)
        {
            try
            {
                await _userHandler.RemoveUpdateUserEducationAsync(userEducationId, _identity);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getUserEducation/{id}")]
        public async Task<ActionResult<List<UserEducationDto>>> GetUserEducation(int id)
        {
            try
            {
                return Ok(await _userHandler.GetUserEducationHandlerAsync(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getUserExperience/{id}")]
        public async Task<ActionResult<List<UserExperienceDto>>> GetUserExperience(int id)
        {
            try
            {
                return Ok(await _userHandler.GetUserExperienceHandlerAsync(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
