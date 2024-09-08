using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services
{
    public interface IUserValidationServices
    {

        Task IsValidUserToRegister(UserRegisterDto userRegisterDto);

    }
}
