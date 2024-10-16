
namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents the data transfer object for creating a user experience.
    /// </summary>
    public class CreateUserExperienceDto
    {
        /// <summary>
        /// Gets or sets the title of the user experience.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the free text associated with the user experience.
        /// </summary>
        public string FreeTxt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user experience is public.
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the start date of the user experience.
        /// </summary>
        public DateOnly StartedAt { get; set; }

        /// <summary>
        /// Gets or sets the end date of the user experience.
        /// </summary>
        public DateOnly EndedAt { get; set; }
    }
}
