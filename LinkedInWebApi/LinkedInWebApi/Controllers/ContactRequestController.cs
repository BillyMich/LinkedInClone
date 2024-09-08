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

        public ContactRequestController(IContactRequestHandler contactRequestHandler)
        {
            _contactRequestHandler = contactRequestHandler;
        }

        [HttpPost("GetConnectedUsers")]
        public async Task<ActionResult<List<UserDto>>> GetConnectedUsers()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var nameIdentificationClaim = identity.FindFirst("NameIdentification")?.Value;

            var result = await _contactRequestHandler.GetConnectedUsers(int.Parse(nameIdentificationClaim));
            return Ok(result);
        }

        [HttpPost("GetConnectedContactsByStatus")]
        public async Task<ActionResult<List<ContactRequestDto>>> GetConnectedContactsByStatus([FromBody] int statusId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var nameIdentificationClaim = identity.FindFirst("NameIdentification")?.Value;

            var result = await _contactRequestHandler.GetConnectedContactsByStatus(int.Parse(nameIdentificationClaim), statusId);
            return Ok(result);
        }

        [HttpPost("CreateContactRequest")]
        public async Task<IActionResult> CreateContactRequest([FromBody] ContactRequestDto contactRequestDto)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var nameIdentificationClaim = identity.FindFirst("NameIdentification")?.Value;

            contactRequestDto.UserRequestId = int.Parse(nameIdentificationClaim);

            var result = await _contactRequestHandler.CreateContactRequest(contactRequestDto);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to create contact request.");
        }
    }
}
