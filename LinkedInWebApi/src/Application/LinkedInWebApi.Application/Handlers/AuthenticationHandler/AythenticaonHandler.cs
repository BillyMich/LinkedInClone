using LinkedInWebApi.Application.Dto;
using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers
{
    public class AuthenticationHandler : IAuthenticationHandler
    {

        private readonly IRegisterUserService _registerUserService;


        public AuthenticationHandler(IRegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }


        public async Task<IResult<bool>> RegisterUserHandler(RegisterDto registerDto)
        {

            var registerUserResult = await _registerUserService.RegisterUserService(registerDto);

            if (registerUserResult.Success)
            {
                return new SuccessResult<bool>(registerUserResult.Data);
            }

            throw new NotImplementedException();
        }
    }
}
