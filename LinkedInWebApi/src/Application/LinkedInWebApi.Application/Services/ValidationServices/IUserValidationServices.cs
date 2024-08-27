using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services.ValidationServices
{
    public interface IUserValidationServices
    {

        Task IsValidUserToRegister(UserRegisterDto userRegisterDto);

    }
}
