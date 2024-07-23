using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Services.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDto> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsersToJson()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsersToXML()
        {
            throw new NotImplementedException();
        }
    }
}
