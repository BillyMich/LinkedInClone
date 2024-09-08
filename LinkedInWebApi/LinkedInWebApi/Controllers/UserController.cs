using LinkedInWebApi.Application.Handlers.UserHandler;
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


        public UserController(IUserHandler userHandler, ClaimsIdentity identity)
        {
            _userHandler = userHandler;
            _identity = identity;
        }




    }
}
