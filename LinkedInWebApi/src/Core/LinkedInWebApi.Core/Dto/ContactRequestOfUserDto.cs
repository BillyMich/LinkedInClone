namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents a DTO for contact requests of a user.
    /// </summary>
    public class ContactRequestOfUserDto
    {
        /// <summary>
        /// Gets or sets the list of contact requests from other users.
        /// </summary>
        public List<ContactRequestDto> ContactRequestsFrom { get; set; }

        /// <summary>
        /// Gets or sets the list of contact requests to other users.
        /// </summary>
        public List<ContactRequestDto> ContactRequestsTo { get; set; }
    }
}
