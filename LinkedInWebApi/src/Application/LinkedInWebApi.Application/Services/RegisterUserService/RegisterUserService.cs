using LinkedInWebApi.Application.Dto;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        Task<IResult<bool>> IRegisterUserService.RegisterUserService(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
