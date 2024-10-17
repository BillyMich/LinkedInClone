namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents an application notification data transfer object.
    /// </summary>
    public class ApplicationNotificationDto
    {
        /// <summary>
        /// Gets or sets the username associated with the notification.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the title of the application associated with the notification.
        /// </summary>
        public string ApplicationTitle { get; set; }
    }
}
