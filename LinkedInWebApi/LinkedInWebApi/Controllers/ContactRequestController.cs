using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    /// <summary>
    /// Controller for managing contact requests.
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class ContactRequestController : Controller
    {
        private readonly IContactRequestHandler _contactRequestHandler;
        private readonly ClaimsIdentity _identity;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRequestController"/> class.
        /// </summary>
        /// <param name="contactRequestHandler">The contact request handler.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public ContactRequestController(IContactRequestHandler contactRequestHandler, IHttpContextAccessor httpContextAccessor)
        {
            _contactRequestHandler = contactRequestHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        /// <summary>
        /// Creates a new contact request.
        /// </summary>
        /// <param name="contactRequestDto">The contact request DTO.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost("CreateContactRequest")]
        [Authorize]
        public async Task<ActionResult> CreateContactRequest([FromBody] NewContactRequestDto contactRequestDto)
        {
            try
            {
                await _contactRequestHandler.CreateContactRequest(contactRequestDto, _identity);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes the status of a contact request.
        /// </summary>
        /// <param name="contactRequestChangeStatusDto">The contact request change status DTO.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost("ChangeStatusOfRequest")]
        [Authorize]
        public async Task<ActionResult<bool>> ChangeStatusOfRequest([FromBody] ContactRequestChangeStatusDto contactRequestChangeStatusDto)
        {
            try
            {
                await _contactRequestHandler.ChangeStatusOfRequest(contactRequestChangeStatusDto, _identity);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the list of connected users.
        /// </summary>
        /// <returns>The list of connected users.</returns>
        [HttpGet("GetConnectedUsers")]
        [Authorize]
        public async Task<ActionResult<List<UserDto>>> GetConnectedUsers()
        {
            try
            {
                return Ok(await _contactRequestHandler.GetConnectedUsers(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the list of non-connected users.
        /// </summary>
        /// <returns>The list of non-connected users.</returns>
        [HttpGet("GetNonConnectedUsers")]
        [Authorize]
        public async Task<ActionResult<List<UserDto>>> GetNonConnectedUsers()
        {
            try
            {
                return Ok(await _contactRequestHandler.GetNonConnectedUsers(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the list of pending connect contacts.
        /// </summary>
        /// <returns>The list of pending connect contacts.</returns>
        [HttpGet("GetPendingConnectContacts")]
        [Authorize]
        public async Task<ActionResult<List<ContactRequestOfUserDto>>> GetPendingConnectContacts()
        {
            try
            {
                return Ok(await _contactRequestHandler.GetPendingConnectContacts(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
