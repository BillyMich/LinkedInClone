using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services.ValidationServices
{
    public interface IUserValidationServices
    {

        Task<bool> IsValidUserToRegister(UserRegisterDto userRegisterDto);

    }
}
