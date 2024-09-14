using System.Security.Claims;

namespace LinkedInWebApi.Core.Helpers
{
    public static class ClaimsIdentityaHelper
    {

        public static int GetUserIdAsync(this System.Security.Claims.ClaimsIdentity claimsIdentity)
        {
            return int.Parse(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
