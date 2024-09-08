namespace LinkedInWebApi.Core.Helpers
{
    public static class ClaimsIdentityaHelper
    {

        public static int GetUserId(this System.Security.Claims.ClaimsIdentity claimsIdentity)
        {
            return int.Parse(claimsIdentity.FindFirst("UserId").Value);
        }
    }
}
