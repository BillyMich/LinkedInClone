namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents the data transfer object for creating user education.
    /// </summary>
    public class CreateUserEducationDto
    {
        /// <summary>
        /// Gets or sets the degree title.
        /// </summary>
        public string DegreeTitle { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the education is public.
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the education type ID.
        /// </summary>
        public int EducationTypeId { get; set; }
    }
}
