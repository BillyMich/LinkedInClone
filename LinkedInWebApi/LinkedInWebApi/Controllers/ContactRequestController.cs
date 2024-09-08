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

        public ContactRequestController(IContactRequestHandler contactRequestHandler, ClaimsIdentity identity)
        {
            _contactRequestHandler = contactRequestHandler;
            _identity = identity;
        }

        [HttpPost("CreateContactRequest")]
        public async Task<ActionResult<bool>> CreateContactRequest([FromBody] ContactRequestDto contactRequestDto)
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

        [HttpGet("GetConnectedContactsByStatus/{statusId}")]
        public async Task<ActionResult<List<ContactRequestDto>>> GetConnectedContactsByStatus(int statusId)
        {
            try
            {
                return Ok(await _contactRequestHandler.GetConnectedContactsByStatus(statusId, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
