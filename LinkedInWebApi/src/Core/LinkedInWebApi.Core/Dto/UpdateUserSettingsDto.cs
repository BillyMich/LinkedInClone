namespace LinkedInWebApi.Core
{
    public class UpdateUserSettingsDto
    {
        public string? Email { get; set; }

        public string? OldPassword { get; set; }

        public string? Password { get; set; }

    }
}