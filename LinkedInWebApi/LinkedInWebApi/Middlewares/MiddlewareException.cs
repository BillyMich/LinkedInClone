// Ignore Spelling: Middleware

using LinkedInWebApi.Extensions;

namespace LinkedInWebApi.Middlewares
{
    public static class MiddlewareException
    {

        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
