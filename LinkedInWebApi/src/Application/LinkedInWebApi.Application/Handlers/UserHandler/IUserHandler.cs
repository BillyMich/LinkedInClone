using LinkedInWebApi.Core;

namespace LinkedInWebApi.Application.Handlers.UserHandler
{
    public interface IUserHandler
    {

        /// <summary>
        /// Get User Handler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto?> GetUserHandler(int id);

        /// <summary>
        /// Get Users Handler
        /// </summary>
        /// <returns></returns>
        Task<List<UserDto>> GetUsersHandler();

        /// <summary> Returns then user list as XML </summary>
        Task<string> GetUsersToXML();

        Task<string> GetUsersToJson();

    }
}
