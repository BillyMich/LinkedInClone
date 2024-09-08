using LinkedInWebApi.Application.Handlers.MessageHandler;
using LinkedInWebApi.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MessageController : Controller
    {

        IMessageHandler _messageHandler;

        public MessageController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        /// <summary>
        /// Get Message by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("getChats")]
        public async Task<ActionResult<ChatDto?>> GetChatsOfUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var nameIdentificationClaim = identity.FindFirst("NameIdentification")?.Value;


            var result = await _messageHandler.GetChatsOfUser(nameIdentificationClaim);
            return Ok(result);
        }

        /// <summary>
        /// Insert a new message
        /// </summary>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        [HttpPost("insertMessage")]
        public async Task<IActionResult> InsertMessage([FromBody] NewMessageDto newMessage)
        {
            var result = await _messageHandler.InsertMessage(newMessage);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to insert message.");
        }


        [HttpPost("getChatMessages")]
        public async Task<ActionResult<List<MessageDto>?>> GetChatMessages([FromBody] GetChatDto getChatDto)
        {
            var result = await _messageHandler.GetMessageOfChat(getChatDto);
            return Ok(result);
        }


    }
}
