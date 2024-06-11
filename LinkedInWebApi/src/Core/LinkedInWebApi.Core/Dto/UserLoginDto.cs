namespace LinkedInWebApi.Core.Dto
{
    /// <summary>
    /// Represents the data transfer object for user login information
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// Gets the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
