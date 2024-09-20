namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents a chat data transfer object.
    /// </summary>
    public class ChatDto
    {
        /// <summary>
        /// Gets or sets the ID of the chat.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user participating in the chat.
        /// </summary>
        public int UserChatingId { get; set; }

        /// <summary>
        /// Gets or sets the name of the chat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last message in the chat.
        /// </summary>
        public string? LastMessage { get; set; }

        /// <summary>
        /// Gets or sets the date of the last message in the chat.
        /// </summary>
        public DateTime? LastMessageDate { get; set; }
    }
}
