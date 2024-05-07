using LinkedInWebApi.Application.Dto;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public interface IAuthenticationHandler
    {

        Task<IResult<bool>> RegisterUserHandler(RegisterDto registerDto);
    }
}
