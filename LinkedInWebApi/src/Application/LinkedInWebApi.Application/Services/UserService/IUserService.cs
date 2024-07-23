using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);

        Task<List<UserDto>> GetUsers();

        Task<string> GetUsersToXML();

        Task<string> GetUsersToJson();
    }
}
