namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents the data transfer object for creating a post.
    /// </summary>
    public class CreatePostDto
    {
        /// <summary>
        /// Gets or sets the free text of the post.
        /// </summary>
        public string FreeTxt { get; set; }
    }
}