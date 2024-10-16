namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents a comment data transfer object.
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// Gets or sets the comment ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the creator of the comment.
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the creator of the comment.
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// Gets or sets the free text of the comment.
        /// </summary>
        public string FreeTxt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
