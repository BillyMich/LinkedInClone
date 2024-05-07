using LinkedInWebApi.Application.Dto;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services
{
    public interface IRegisterUserService
    {

        Task<IResult<bool>> RegisterUserService(RegisterDto registerDto);
    }
}
