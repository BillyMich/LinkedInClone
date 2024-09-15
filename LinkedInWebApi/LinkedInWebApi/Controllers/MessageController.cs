using LinkedInWebApi.Application.Handlers.MessageHandler;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/message/")]
    [ApiController]
    public class MessageController : Controller
    {

        IMessageHandler _messageHandler;
        private readonly ClaimsIdentity _identity;

        public MessageController(IMessageHandler messageHandler, IHttpContextAccessor httpContextAccessor)
        {
            _messageHandler = messageHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        /// <summary>
        /// Inserts a new message.
        /// </summary>
        /// <param name="newMessage">The new message to insert.</param>
        /// <returns>A boolean indicating whether the message was successfully inserted.</returns>
        [HttpPost("CreateMessage")]
        [Authorize]
        public async Task<ActionResult> InsertMessage([FromBody] NewMessageDto newMessage)
        {
            try
            {
                await _messageHandler.InsertMessageAsync(newMessage, _identity);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retrieves the chats of the current user.
        /// </summary>
        /// <returns>A list of chat DTOs.</returns>
        [HttpGet("GetChatsOfUser")]
        [Authorize]
        public async Task<ActionResult<List<ChatDto>?>> GetChatsOfUser()
        {
            try
            {
                return Ok(await _messageHandler.GetChatsOfUserAsync(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retrieves the messages of a chat.
        /// </summary>
        /// <param name="getChatDto">The DTO containing the chat information.</param>
        /// <returns>A list of message DTOs.</returns>
        [HttpPost("GetMessageOfChat")]
        [Authorize]
        public async Task<ActionResult<List<MessageDto>>> GetMessageOfChat([FromBody] GetChatDto getChatDto)
        {
            try
            {
                return Ok(await _messageHandler.GetMessageOfChatAsync(getChatDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
