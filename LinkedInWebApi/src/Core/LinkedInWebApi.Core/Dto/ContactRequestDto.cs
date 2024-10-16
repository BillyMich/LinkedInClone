namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents a contact request DTO.
    /// </summary>
    public class ContactRequestDto
    {
        /// <summary>
        /// Gets or sets the ID of the contact request.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user receiver.
        /// </summary>
        public int UserResiverId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contact request is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contact request is accepted.
        /// </summary>
        public bool IsAccepted { get; set; }
    }
}
