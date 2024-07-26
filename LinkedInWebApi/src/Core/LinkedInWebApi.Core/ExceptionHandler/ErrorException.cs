using System.Net;

namespace LinkedInWebApi.Core.ExceptionHandler
{
    public static class ErrorException
    {

        public static readonly HttpStatusCodeException AuthenticationException = new(HttpStatusCode.Unauthorized, "Authentication failed", 401);
    }
}
