using LinkedInWebApi.Application.Handlers.MessageHandler;
using LinkedInWebApi.Core;
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

        public MessageController(IMessageHandler messageHandler, ClaimsIdentity identity)
        {
            _messageHandler = messageHandler;
            _identity = identity;
        }

        [HttpPost("InsertMessage")]
        public async Task<ActionResult<bool>> InsertMessage([FromBody] NewMessageDto newMessage)
        {
            try
            {
                return Ok(await _messageHandler.InsertMessage(newMessage, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("GetChatsOfUser")]
        public async Task<ActionResult<List<ChatDto>?>> GetChatsOfUser(string userId)
        {
            try
            {
                return Ok(await _messageHandler.GetChatsOfUser(userId, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("GetMessageOfChat")]
        public async Task<ActionResult<List<MessageDto>>> GetMessageOfChat([FromBody] GetChatDto getChatDto)
        {
            try
            {
                return Ok(await _messageHandler.GetMessageOfChat(getChatDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
