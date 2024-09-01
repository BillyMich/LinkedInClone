using System.Net;

namespace LinkedInWebApi.Core.ExceptionHandler
{
    public static class ErrorException
    {

        public static readonly HttpStatusCodeException AuthenticationException = new(HttpStatusCode.Unauthorized, "Authentication failed", 401);

        public static readonly HttpStatusCodeException NoUserFountWithGivenIdException = new(HttpStatusCode.NotFound, "No user found with given id", 404);

        public static readonly HttpStatusCodeException EmailAlreadyExistsFromAnotherUserException = new(HttpStatusCode.NotFound, "Email already exist from another user", 400);

        public static readonly HttpStatusCodeException UnexpectedBehaviorException = new(HttpStatusCode.InternalServerError, "Please try again later...", 500);
    }
}
