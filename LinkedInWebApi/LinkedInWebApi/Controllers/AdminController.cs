using LinkedInWebApi.Application.Handlers.UserHandler;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    /// <summary>
    /// Controller for handling administrative tasks related to users.
    /// </summary>
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IUserHandler _userHandler;
        private readonly ClaimsIdentity _identity;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="userHandler">The user handler.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public AdminController(IUserHandler userHandler, IHttpContextAccessor httpContextAccessor)
        {
            _userHandler = userHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        /// <summary>
        /// Gets the users in XML format.
        /// </summary>
        /// <param name="ids">The list of user IDs.</param>
        /// <returns>The users in XML format.</returns>
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

        /// <summary>
        /// Gets the users in JSON format.
        /// </summary>
        /// <param name="ids">The list of user IDs.</param>
        /// <returns>The users in JSON format.</returns>
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
    }
}
