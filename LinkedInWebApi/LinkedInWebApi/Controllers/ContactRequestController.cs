using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ContactRequestController : Controller
    {

        private readonly IContactRequestHandler _contactRequestHandler;
        private readonly ClaimsIdentity _identity;

        public ContactRequestController(IContactRequestHandler contactRequestHandler, IHttpContextAccessor httpContextAccessor)
        {
            _contactRequestHandler = contactRequestHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        [HttpPost("CreateContactRequest")]
        public async Task<ActionResult<bool>> CreateContactRequest([FromBody] NewContactRequestDto contactRequestDto)
        {
            try
            {
                return Ok(await _contactRequestHandler.CreateContactRequest(contactRequestDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ChangeStatusOfRequest")]
        public async Task<ActionResult<bool>> ChangeStatusOfRequest([FromBody] ContactRequestChangeStatusDto contactRequestChangeStatusDto)
        {
            try
            {
                return Ok(await _contactRequestHandler.ChangeStatusOfRequest(contactRequestChangeStatusDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetConnectedUsers")]
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

        [HttpGet("GetNonConnectedUsers")]
        public async Task<ActionResult<List<UserDto>>> GetNonConnectedUsers()
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

        [HttpGet("GetPendingConnectContacts")]
        public async Task<ActionResult<List<NewContactRequestDto>>> GetPendingConnectContacts()
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
