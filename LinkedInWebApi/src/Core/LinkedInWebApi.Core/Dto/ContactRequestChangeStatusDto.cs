namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents a DTO for changing the status of a contact request.
    /// </summary>
    public class ContactRequestChangeStatusDto
    {
        /// <summary>
        /// Gets or sets the ID of the contact request.
        /// </summary>
        public int ContactRequestId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the status.
        /// </summary>
        public int StatusId { get; set; }
    }
}
