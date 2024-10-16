namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents the data transfer object for creating a post comment.
    /// </summary>
    public class CreatePostCommentDto
    {
        /// <summary>
        /// Gets or sets the ID of the post.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the free text of the comment.
        /// </summary>
        public string FreeTxt { get; set; }
    }
}
